using Bwr.Web.Models.Mobile.Slider;
using System.Collections.Generic;

namespace Bwr.Web.Factories.Mobile
{
    public partial interface ISliderMobFactory
    {
        IList<SliderMobModel> GetSliders();
    }
}
