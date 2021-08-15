using Bwr.Web.Models.Catalog;
using System.Collections.Generic;

namespace Bwr.Web.Factories.Mobile
{
    public interface IHomepageBestSellersMobFactory
    {
        IEnumerable<ProductOverviewModel> GetHomepageBestSellers(int? productThumbPictureSize);
    }
}
