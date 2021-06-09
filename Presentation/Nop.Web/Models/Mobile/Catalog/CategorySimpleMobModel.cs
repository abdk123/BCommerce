using System.Collections.Generic;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class CategorySimpleMobModel
    {
        public CategorySimpleMobModel()
        {
            SubCategories = new List<CategorySimpleMobModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? NumberOfProducts { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool HaveSubCategories { get; set; }

        public List<CategorySimpleMobModel> SubCategories { get; set; }


    }
}
