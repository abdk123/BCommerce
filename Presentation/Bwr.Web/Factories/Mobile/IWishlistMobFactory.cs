using Bwr.Web.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Factories.Mobile
{
    public interface IWishlistMobFactory
    {
        WishlistModel Wishlist(Guid? customerGuid);
    }
}
