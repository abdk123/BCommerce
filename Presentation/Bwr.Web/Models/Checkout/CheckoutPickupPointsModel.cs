using System.Collections.Generic;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Checkout
{
    public class CheckoutPickupPointsModel : BaseNopModel
    {
        public CheckoutPickupPointsModel()
        {
            Warnings = new List<string>();
            PickupPoints = new List<CheckoutPickupPointModel>();
        }

        public IList<string> Warnings { get; set; }

        public IList<CheckoutPickupPointModel> PickupPoints { get; set; }
        public bool AllowPickupInStore { get; set; }
        public bool PickupInStore { get; set; }
        public bool PickupInStoreOnly { get; set; }
        public bool DisplayPickupPointsOnMap { get; set; }
        public string GoogleMapsApiKey { get; set; }
    }
}
