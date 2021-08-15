using System.Collections.Generic;
using Bwr.Web.Framework.Models;
using Bwr.Web.Models.Common;

namespace Bwr.Web.Models.Profile
{
    public partial class ProfilePostsModel : BaseNopModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}