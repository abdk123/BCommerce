using Nop.Web.Models.Mobile.Slider;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public partial interface ISliderMobFactory
    {
        IList<SliderMobModel> GetSliders();
    }
}
