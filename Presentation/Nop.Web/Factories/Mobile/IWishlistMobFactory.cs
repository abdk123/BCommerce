using Nop.Web.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories.Mobile
{
    public interface IWishlistMobFactory
    {
        WishlistModel Wishlist(Guid? customerGuid);
    }
}
