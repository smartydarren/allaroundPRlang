
namespace webapiLearn.Models
{
    public class GetStagingProductPricingResponse
    {
        public GetProductPricingConfigurationStaging ProductPricingConfigurationStaging { get; set; }

        public List<GetPricingPurchasingOptionItem> PurchasingOptions { get; set; }

        public GetStagingProductPricingResponse()
        {
            this.PurchasingOptions = new List<GetPricingPurchasingOptionItem>();
        }

        public class GetProductPricingConfigurationStaging
        {
            public long Id { get; set; }

            public int PricingConfigurationId { get; set; }

            public string PriceVariesBy { get; set; }
        }

        public class GetPricingPurchasingOptionItem
        {
            public long Id { get; set; }

            public PricingBillingFrequency BillingFrequency { get; set; }

            public string Name { get; set; }

            public int Term { get; set; }

            public GetPricingOfferLevel OfferLevel { get; set; }

            public List<GetPricingItemStaging> ItemCatalogStaging { get; set; }

            public GetPricingPurchasingOptionItem()
            {
                ItemCatalogStaging = new List<GetPricingItemStaging>();
            }

        }

        public class GetPricingItemStaging
        {
            public long Id { get; set; }

            public decimal Price { get; set; }

            public decimal FullPurchasePrice { get; set; }

            public decimal InterestRate { get; set; }

            public string PricingType { get; set; }

            public SkuItem ItemStaging { get; set; }
        }

        public class SkuItem
        {
            public long Id { set; get; }

            public string SKU { get; set; }
        }

        public class PricingBillingFrequency
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }
        }

        public class GetPricingOfferLevel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

    }

}
