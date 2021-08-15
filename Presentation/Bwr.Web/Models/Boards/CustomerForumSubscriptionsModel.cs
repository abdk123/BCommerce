using System.Collections.Generic;
using Bwr.Web.Framework.Models;
using Bwr.Web.Models.Common;

namespace Bwr.Web.Models.Boards
{
    public partial class CustomerForumSubscriptionsModel : BaseNopModel
    {
        public CustomerForumSubscriptionsModel()
        {
            ForumSubscriptions = new List<ForumSubscriptionModel>();
        }

        public IList<ForumSubscriptionModel> ForumSubscriptions { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested classes

        public partial class ForumSubscriptionModel : BaseNopEntityModel
        {
            public int ForumId { get; set; }
            public int ForumTopicId { get; set; }
            public bool TopicSubscription { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
        }

        #endregion
    }
}