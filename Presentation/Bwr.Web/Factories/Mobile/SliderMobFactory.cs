using Bwr.Core;
using Bwr.Core.Caching;
using Bwr.Services.Caching;
using Bwr.Services.Configuration;
using Bwr.Services.Media;
using Bwr.Web.Models.Mobile.Slider;
using System.Collections.Generic;
using System.Linq;

namespace Bwr.Web.Factories.Mobile
{
    public class SliderMobFactory : ISliderMobFactory
    {
        private readonly ICacheKeyService _cacheKeyService;
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public SliderMobFactory(ICacheKeyService cacheKeyService,
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
            
            var settings = _settingService.GetAllSettings()
                .Where(x => x.Name.Contains("nivoslidersettings.picture") || x.Name.Contains("nivoslidersettings.alttext")).ToList();

            if (settings != null)
            {
                //Slide1
                var pictureSetting1 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.picture1id"));
                var altTextSetting1 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.alttext1"));
                if (pictureSetting1 != null && pictureSetting1.Value != "0")
                {
                    list.Add(new SliderMobModel()
                    {
                        AlternateText = altTextSetting1!=null ? altTextSetting1.Value:string.Empty,
                        ImageUrl = GetPictureUrl(pictureSetting1.Value)
                    });
                }

                //Slide2
                var pictureSetting2 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.picture2id"));
                var altTextSetting2 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.alttext2"));
                if (pictureSetting2 != null && pictureSetting2.Value != "0")
                {
                    list.Add(new SliderMobModel()
                    {
                        AlternateText = altTextSetting2 != null ? altTextSetting2.Value : string.Empty,
                        ImageUrl = GetPictureUrl(pictureSetting2.Value)
                    });
                }

                //Slide3
                var pictureSetting3 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.picture3id"));
                var altTextSetting3 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.alttext3"));
                if (pictureSetting3 != null && pictureSetting3.Value != "0")
                {
                    list.Add(new SliderMobModel()
                    {
                        AlternateText = altTextSetting3 != null ? altTextSetting3.Value : string.Empty,
                        ImageUrl = GetPictureUrl(pictureSetting3.Value)
                    });
                }

                //Slide4
                var pictureSetting4 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.picture4id"));
                var altTextSetting4 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.alttext4"));
                if (pictureSetting4 != null && pictureSetting4.Value != "0")
                {
                    list.Add(new SliderMobModel()
                    {
                        AlternateText = altTextSetting4 != null ? altTextSetting4.Value : string.Empty,
                        ImageUrl = GetPictureUrl(pictureSetting4.Value)
                    });
                }

                //Slide5
                var pictureSetting5 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.picture5id"));
                var altTextSetting5 = settings.FirstOrDefault(x => x.Name.Contains("nivoslidersettings.alttext5"));
                if (pictureSetting5 != null && pictureSetting5.Value != "0")
                {
                    list.Add(new SliderMobModel()
                    {
                        AlternateText = altTextSetting5 != null ? altTextSetting5.Value : string.Empty,
                        ImageUrl =  GetPictureUrl(pictureSetting5.Value)
                    });
                }

            }
            
            return list;
        }

        protected string GetPictureUrl(string pictureId)
        {
            string url = "";
            int id;
            if(int.TryParse(pictureId,out id))
            {
                url = _pictureService.GetPictureUrl(id);
            }
            
            return url;
        }
    }
}
