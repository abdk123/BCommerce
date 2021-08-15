using Bwr.Web.Areas.Admin.Models.Home;

namespace Bwr.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the home models factory
    /// </summary>
    public partial interface IHomeModelFactory
    {
        /// <summary>
        /// Prepare dashboard model
        /// </summary>
        /// <param name="model">Dashboard model</param>
        /// <returns>Dashboard model</returns>
        DashboardModel PrepareDashboardModel(DashboardModel model);

        /// <summary>
        /// Prepare bwire news model
        /// </summary>
        /// <returns>bwire news model</returns>
        NopCommerceNewsModel PrepareNopCommerceNewsModel();
    }
}