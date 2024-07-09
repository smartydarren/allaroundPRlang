namespace webapiLearn.Models.BssModels
{
    public class GetPlanAndFeaturesCarrierGroupsStagingResponseItem
    {
        public long Id { get; set; }
        public long PlanAndFeatureCarrierGroupId { get; set; }
        public long CarrierGroupId { get; set; }
        public string CarrierGroup { get; set; }
        public long ProductCarrierId { get; set; }
        public long ProductCarriersStagingId { get; set; }
        public long ProductId { get; set; }
        public long ProductsStagingId { get; set; }
        public string ProductStagingCarrierCode { get; set; }
        public string ProductStagingCarrierName { get; set; }
        public long ProductStagingBSSNetworkId { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
