using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Models.Mobile.ShoppingCart
{
    public class UpdatedItemsInCart
    {
        public UpdatedItemsInCart()
        {
            ProductAttributes = new List<ProductAttribute>();
        }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public List<ProductAttribute> ProductAttributes { get; set; }
    }
    public class ProductAttribute
    {
        public int AttributeId { get; set; }
        public StringValues Values { get; set; }
    }
}
