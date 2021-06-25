using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.ShoppingCart
{
    public class OrderTotalMobModel : BaseNopModel
    {
        public OrderTotalMobModel()
        {
        }

        public string SubTotal { get; set; }

        public string SubTotalDiscount { get; set; }

        public string Shipping { get; set; }
        public string OrderTotalDiscount { get; set; }
        public string OrderTotal { get; set; }
    }
}
