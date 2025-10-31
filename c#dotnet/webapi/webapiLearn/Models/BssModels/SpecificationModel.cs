namespace webapiLearn.Models.BssModels
{
    public class SpecificationStaging
    {
        public long? Id { get; set; }
        public long ProductSpecificationsId { get; set; }
        public long SpecificationTypeId { get; set; }
        public long? ProductId { get; set; }
        public long StagingProductId { get; set; }
        public int MeasurementUnitId { get; set; }
        public bool IsActive { get; set; }
        public bool SetBySKU { get; set; }
        public long DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string SpecificationName { get; set; }
        public string Type { get; set; }
        public string Measurement { get; set; }
        public long ItemSpecificationId { get; set; }
        public List<SpecificationValueStaging> ProductSpecificationValuesStaging { get; set; }

        public SpecificationStaging()
        {
            ProductSpecificationValuesStaging = new List<SpecificationValueStaging>();
        }
    }

    public class SpecificationValueStaging
    {
        public long Id { get; set; }
        public long ProductSpecificationValuesId { get; set; }
        public long ProductSpecificationId { get; set; }
        public long ProdSpecStagingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public List<SpecificationAssignmentStaging> ProductSpecificationAssignmentsStaging { get; set; }

        public SpecificationValueStaging()
        {
            ProductSpecificationAssignmentsStaging = new List<SpecificationAssignmentStaging>();
        }
    }
    public class SpecificationAssignmentStaging
    {
        public long Id { get; set; }
        public long ProdSpecAssignmentId { get; set; }
        public long SpecificationValueId { get; set; }
        public long AssignToSpecificationValueId { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
