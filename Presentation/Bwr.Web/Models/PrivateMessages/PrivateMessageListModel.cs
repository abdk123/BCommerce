using System.Collections.Generic;
using Bwr.Web.Framework.Models;
using Bwr.Web.Models.Common;

namespace Bwr.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseNopModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}