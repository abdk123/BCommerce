﻿using Bwr.Web.Framework.Mvc.ModelBinding;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.News
{
    public partial class AddNewsCommentModel : BaseNopModel
    {
        [NopResourceDisplayName("News.Comments.CommentTitle")]
        public string CommentTitle { get; set; }

        [NopResourceDisplayName("News.Comments.CommentText")]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}