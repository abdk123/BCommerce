using Microsoft.AspNetCore.Mvc;
using Bwr.Services.Security;
using Bwr.Web.Factories.Mobile;
using System;

namespace Bwr.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistMobFactory _wishlistMobFactory;
        private readonly IPermissionService _permissionService;
        public WishlistController(IWishlistMobFactory wishlistMobFactory , IPermissionService permissionService)
        {
            _wishlistMobFactory = wishlistMobFactory;
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult GetWishlist(Guid? customerGuid)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.EnableWishlist))
                return BadRequest("NotAuthorize");

            var model = _wishlistMobFactory.Wishlist(customerGuid);
            if (model == null)
                return BadRequest();

            return Ok(model);
        }
    }
}
