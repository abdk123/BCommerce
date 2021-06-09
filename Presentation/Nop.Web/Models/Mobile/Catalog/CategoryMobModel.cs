using Nop.Web.Models.Mobile.Media;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class CategoryMobModel
    {
        public CategoryMobModel()
        {
            Picture = new PictureMobModel();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public PictureMobModel Picture { get; set; }
    }
}
