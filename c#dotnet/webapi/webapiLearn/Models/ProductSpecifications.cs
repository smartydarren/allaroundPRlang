using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace webapiLearn.Models
{
    public class ProductSpecification
    {

        [JsonProperty(PropertyName = "Id")]
        public long ProductSpecificationId { get; set; }
        public long SpecificationTypeId { get; set; }
        public long ProductId { get; set; }
        public int MeasurementUnitId { get; set; }
        public string MeasurementName { get; set; }
        public string MeasurementAbbreviation { get; set; }
        public bool IsActive { get; set; }
        public bool SetBySKU { get; set; }
        public string SpecificationName { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public string Measurement { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public List<ProductSpecificationValue> ProductSpecificationValues { get; set; }

        public ProductSpecification()
        {
            ProductSpecificationValues = new List<ProductSpecificationValue>();
        }
    }
    public class ProductSpecificationValue
{

        [JsonProperty(PropertyName = "Id")]
        public long ProductSpecificationValueId { get; set; }
        public long ProductSpecificationId { get; set; }
        public string Name {get; set;}
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public List<ProductSpecificationAssignment> ProductSpecificationAssignments { get; set; }

        public ProductSpecificationValue()
        {
            ProductSpecificationAssignments = new List<ProductSpecificationAssignment>();
        }

    }
    
    public class ProductSpecificationAssignment
    {
        [JsonProperty(PropertyName = "Id")]
        public long ProductSpecificationAssignmentId { get; set; }
      
        public long SpecificationValueId { get; set; }
      
        public string SpecificationName { get; set; }
      
        public string SpecificationValue { get; set; }
       
        public long AssignToSpecificationValueId { get; set; }
        public string AssignToSpecificationName { get; set; }
        public string AssignToSpecificationValue { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }

    }
   
}