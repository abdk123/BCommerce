
namespace Bwr.Web.Framework.Models
{
    /// <summary>
    /// Represents base bwire entity model
    /// </summary>
    public partial class BaseNopEntityModel : BaseNopModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}