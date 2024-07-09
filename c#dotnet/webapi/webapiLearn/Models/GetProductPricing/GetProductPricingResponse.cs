using Newtonsoft.Json;

namespace Bruin.BssService.OutSystem.Models
{
    public class GetProductPricingResponse
    {
        public GetProductPricingConfiguration ProductPricingConfiguration { get; set; }

        public List<GetPricingPurchasingOptionItem> PurchasingOptions { get; set; }

        public GetProductPricingResponse()
        {
            this.PurchasingOptions = new List<GetPricingPurchasingOptionItem>();
        }

        public class GetProductPricingConfiguration
        {
            [JsonProperty(PropertyName = "Id")]
            public long ProductPricingConfigurationId { get; set; }

            public int PricingConfigurationId { get; set; }

            public string PriceVariesBy { get; set; }
        }

        public class GetPricingPurchasingOptionItem
        {
            
            [JsonProperty(PropertyName = "Id")]
            public long PurchasingOptionId { get; set; }

            public PricingBillingFrequency BillingFrequency { get; set; }

            public string Name { get; set; }

            public int Term { get; set; }

            public GetPricingOfferLevel OfferLevel { get; set; }

            public List<GetPricingItemStaging> ItemCatalogs { get; set; }

            
        }

        public class GetPricingItemStaging
        {
            
            [JsonProperty(PropertyName = "Id")]
            public long ItemCatalogId { get; set; }

            public decimal Price { get; set; }

            public SkuItem Items { get; set; }

            public RateCard RateCard { get; set; }
        }

        public class SkuItem
        {
            [JsonProperty(PropertyName = "Id")]
            public long ItemId { set; get; }

            public string SKU { get; set; }
        }

        public class PricingBillingFrequency
        {
            [JsonProperty(PropertyName = "Id")]
            public int BillingFrequencyId { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }
        }

        public class GetPricingOfferLevel
        {
            [JsonProperty(PropertyName = "Id")]
            public int OfferLevelId { get; set; }

            public string Name { get; set; }
        }

        public class RateCard
        {
            [JsonIgnore]
            public int RateCardId { get; set; }
            public string QuoteId { get; set; }
            public string OpportunityId { get; set; }
            [JsonIgnore]
            public int DiscountTypeId { get; set; }
            public string DiscountTypeName { get; set; }
            public decimal DiscountAmount { get; set; }
            public int? BruinContractId { get; set; }
            public string ContractDocId { get; set; }
        }

    }

}
