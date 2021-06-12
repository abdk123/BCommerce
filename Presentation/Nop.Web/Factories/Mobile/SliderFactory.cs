using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Caching;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Models.Mobile.Slider;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public class SliderFactory : ISliderFactory
    {
        private readonly ICacheKeyService _cacheKeyService;
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public SliderFactory(ICacheKeyService cacheKeyService,
            IStoreContext storeContext,
            IStaticCacheManager staticCacheManager,
            ISettingService settingService,
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            _cacheKeyService = cacheKeyService;
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
        }
        public IList<SliderMobModel> GetSliders()
        {
            var list = new List<SliderMobModel>();

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var nivoSliderSettings = _settingService.LoadSetting<SliderMobSetting>(storeScope);
            
            if(nivoSliderSettings.Picture1Id > 0)
            {
                list.Add(new SliderMobModel()
                {
                    AlternateText = nivoSliderSettings.AltText1,
                    ImageUrl = GetPictureUrl(nivoSliderSettings.Picture1Id)
                });
            }
            return null;
        }

        protected string GetPictureUrl(int pictureId)
        {
            var url = _pictureService.GetPictureUrl(pictureId);

            return url;
        }
    }
}
