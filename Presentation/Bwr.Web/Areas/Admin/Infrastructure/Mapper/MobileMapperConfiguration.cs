using AutoMapper;
using Bwr.Core.Infrastructure.Mapper;
using Bwr.Web.Models.Catalog;
using Bwr.Web.Models.Mobile.Catalog;

namespace Bwr.Web.Areas.Admin.Infrastructure.Mapper
{
    public class MobileMapperConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 1;

        public MobileMapperConfiguration()
        {
            CreateMap<CategoryModel, CategoryMobModel>();
            CreateMap<CategorySimpleModel, CategorySimpleMobModel>();
        }
    }
}
