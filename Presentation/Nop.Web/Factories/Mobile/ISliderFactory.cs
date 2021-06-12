using Nop.Web.Models.Mobile.Slider;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public interface ISliderFactory
    {
        IList<SliderMobModel> GetSliders();
    }
}
