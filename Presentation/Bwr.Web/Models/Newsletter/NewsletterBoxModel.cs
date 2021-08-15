using System.ComponentModel.DataAnnotations;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Newsletter
{
    public partial class NewsletterBoxModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        public string NewsletterEmail { get; set; }
        public bool AllowToUnsubscribe { get; set; }
    }
}