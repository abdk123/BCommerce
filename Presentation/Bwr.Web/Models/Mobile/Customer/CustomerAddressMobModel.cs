using Bwr.Web.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Models.Mobile.Customer
{
    public class CustomerAddressMobModel
    {
        public CustomerAddressMobModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}
