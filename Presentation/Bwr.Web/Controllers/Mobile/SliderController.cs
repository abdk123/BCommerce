using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bwr.Web.Factories.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderMobFactory _sliderFactory;
        public SliderController(ISliderMobFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }

        [HttpGet]
        public IActionResult GetSliders()
        {
            var model = _sliderFactory.GetSliders();
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }
    }
}
