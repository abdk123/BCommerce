using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.PrivateMessages
{
    public partial class PrivateMessageIndexModel : BaseNopModel
    {
        public int InboxPage { get; set; }
        public int SentItemsPage { get; set; }
        public bool SentItemsTabSelected { get; set; }
    }
}