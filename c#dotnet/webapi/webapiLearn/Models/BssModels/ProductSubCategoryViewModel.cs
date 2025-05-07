namespace webapiLearn.Models.BssModels;
public class ProductSubcategoryViewModel
{
  public long Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public long ProductCategoryId { get; set; }
  public string ProductCategoryName { get; set; }
  public bool? IsVisible { get; set; }
  public bool? IsPromoted { get; set; }
  public bool? RequireAddress { get; set; }
  public int DefaultProductImageOptionId { get; set; }
  public string DefaultProductImageOption { get; set; }
  public long? CustomImageId { get; set; }
  public string CustomImageUrl { get; set; }
  public int ProductCount { get; set; }
  public int Order { get; set; }
}