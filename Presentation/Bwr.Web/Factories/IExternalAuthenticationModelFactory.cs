using System.Collections.Generic;
using Bwr.Web.Models.Customer;

namespace Bwr.Web.Factories
{
    /// <summary>
    /// Represents the interface of the external authentication model factory
    /// </summary>
    public partial interface IExternalAuthenticationModelFactory
    {
        /// <summary>
        /// Prepare the external authentication method model
        /// </summary>
        /// <returns>List of the external authentication method model</returns>
        List<ExternalAuthenticationMethodModel> PrepareExternalMethodsModel();
    }
}
