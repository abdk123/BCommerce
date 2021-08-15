using Bwr.Core.Domain.Customers;
using Bwr.Core.Domain.Orders;
using Bwr.Web.Models.Mobile.Checkout;
using Bwr.Web.Models.Mobile.Customer;
using Bwr.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Factories.Mobile
{
    public interface ICustomerMobFactory
    {
        IList<BillingAddressMobModel> PrepareCustomerAddressesModel(Customer customer);
        CustomerOrderListModel PrepareCustomerOrderListModel(Customer customer);
        OrderDetailsModel PrepareOrderDetailsModel(Order order);
    }
}
