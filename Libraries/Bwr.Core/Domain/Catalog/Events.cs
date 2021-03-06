namespace Bwr.Core.Domain.Catalog
{
    /// <summary>
    /// Product review approved event
    /// </summary>
    public class ProductReviewApprovedEvent
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="productReview">Product review</param>
        public ProductReviewApprovedEvent(ProductReview productReview)
        {
            ProductReview = productReview;
        }

        /// <summary>
        /// Product review
        /// </summary>
        public ProductReview ProductReview { get; }
    }
}