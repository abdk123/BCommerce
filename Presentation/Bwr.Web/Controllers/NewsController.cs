﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Bwr.Core;
using Bwr.Core.Domain.Localization;
using Bwr.Core.Domain.News;
using Bwr.Core.Domain.Security;
using Bwr.Core.Rss;
using Bwr.Services.Customers;
using Bwr.Services.Events;
using Bwr.Services.Localization;
using Bwr.Services.Logging;
using Bwr.Services.Messages;
using Bwr.Services.News;
using Bwr.Services.Security;
using Bwr.Services.Seo;
using Bwr.Services.Stores;
using Bwr.Web.Factories;
using Bwr.Web.Framework;
using Bwr.Web.Framework.Controllers;
using Bwr.Web.Framework.Mvc;
using Bwr.Web.Framework.Mvc.Filters;
using Bwr.Web.Models.News;

namespace Bwr.Web.Controllers
{
    public partial class NewsController : BasePublicController
    {
        #region Fields

        private readonly CaptchaSettings _captchaSettings;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly INewsModelFactory _newsModelFactory;
        private readonly INewsService _newsService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly NewsSettings _newsSettings;

        #endregion

        #region Ctor

        public NewsController(CaptchaSettings captchaSettings,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            INewsModelFactory newsModelFactory,
            INewsService newsService,
            IPermissionService permissionService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings,
            NewsSettings newsSettings)
        {
            _captchaSettings = captchaSettings;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _newsModelFactory = newsModelFactory;
            _newsService = newsService;
            _permissionService = permissionService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
            _newsSettings = newsSettings;
        }

        #endregion

        #region Methods

        public virtual IActionResult List(NewsPagingFilteringModel command)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("Homepage");

            var model = _newsModelFactory.PrepareNewsItemListModel(command);
            return View(model);
        }

        public virtual IActionResult ListRss(int languageId)
        {
            var feed = new RssFeed(
                $"{_localizationService.GetLocalized(_storeContext.CurrentStore, x => x.Name)}: News",
                "News",
                new Uri(_webHelper.GetStoreLocation()),
                DateTime.UtcNow);

            if (!_newsSettings.Enabled)
                return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));

            var items = new List<RssItem>();
            var newsItems = _newsService.GetAllNews(languageId, _storeContext.CurrentStore.Id);
            foreach (var n in newsItems)
            {
                var newsUrl = Url.RouteUrl("NewsItem", new { SeName = _urlRecordService.GetSeName(n, n.LanguageId, ensureTwoPublishedLanguages: false) }, _webHelper.CurrentRequestProtocol);
                items.Add(new RssItem(n.Title, n.Short, new Uri(newsUrl), $"urn:store:{_storeContext.CurrentStore.Id}:news:blog:{n.Id}", n.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));
        }

        public virtual IActionResult NewsItem(int newsItemId)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("Homepage");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null)
                return InvokeHttp404();

            var notAvailable =
                //published?
                !newsItem.Published ||
                //availability dates
                !_newsService.IsNewsAvailable(newsItem) ||
                //Store mapping
                !_storeMappingService.Authorize(newsItem);
            //Check whether the current user has a "Manage news" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            var hasAdminAccess = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageNews);
            if (notAvailable && !hasAdminAccess)
                return InvokeHttp404();

            var model = new NewsItemModel();
            model = _newsModelFactory.PrepareNewsItemModel(model, newsItem, true);

            //display "edit" (manage) link
            if (hasAdminAccess)
                DisplayEditLink(Url.Action("NewsItemEdit", "News", new { id = newsItem.Id, area = AreaNames.Admin }));

            return View(model);
        }

        [HttpPost, ActionName("NewsItem")]
        [AutoValidateAntiforgeryToken]
        [FormValueRequired("add-comment")]
        [ValidateCaptcha]
        public virtual IActionResult NewsCommentAdd(int newsItemId, NewsItemModel model, bool captchaValid)
        {
            if (!_newsSettings.Enabled)
                return RedirectToRoute("Homepage");

            var newsItem = _newsService.GetNewsById(newsItemId);
            if (newsItem == null || !newsItem.Published || !newsItem.AllowComments)
                return RedirectToRoute("Homepage");

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnNewsCommentPage && !captchaValid)
            {
                ModelState.AddModelError("", _localizationService.GetResource("Common.WrongCaptchaMessage"));
            }

            if (_customerService.IsGuest(_workContext.CurrentCustomer) && !_newsSettings.AllowNotRegisteredUsersToLeaveComments)
            {
                ModelState.AddModelError("", _localizationService.GetResource("News.Comments.OnlyRegisteredUsersLeaveComments"));
            }

            if (ModelState.IsValid)
            {
                var comment = new NewsComment
                {
                    NewsItemId = newsItem.Id,
                    CustomerId = _workContext.CurrentCustomer.Id,
                    CommentTitle = model.AddNewComment.CommentTitle,
                    CommentText = model.AddNewComment.CommentText,
                    IsApproved = !_newsSettings.NewsCommentsMustBeApproved,
                    StoreId = _storeContext.CurrentStore.Id,
                    CreatedOnUtc = DateTime.UtcNow,
                };

                _newsService.InsertNewsComment(comment);

                //notify a store owner;
                if (_newsSettings.NotifyAboutNewNewsComments)
                    _workflowMessageService.SendNewsCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);

                //activity log
                _customerActivityService.InsertActivity("PublicStore.AddNewsComment",
                    _localizationService.GetResource("ActivityLog.PublicStore.AddNewsComment"), comment);

                //raise event
                if (comment.IsApproved)
                    _eventPublisher.Publish(new NewsCommentApprovedEvent(comment));

                //The text boxes should be cleared after a comment has been posted
                //That' why we reload the page
                TempData["Bwr.news.addcomment.result"] = comment.IsApproved
                    ? _localizationService.GetResource("News.Comments.SuccessfullyAdded")
                    : _localizationService.GetResource("News.Comments.SeeAfterApproving");

                return RedirectToRoute("NewsItem", new { SeName = _urlRecordService.GetSeName(newsItem, newsItem.LanguageId, ensureTwoPublishedLanguages: false) });
            }

            //If we got this far, something failed, redisplay form
            model = _newsModelFactory.PrepareNewsItemModel(model, newsItem, true);
            return View(model);
        }

        #endregion
    }
}