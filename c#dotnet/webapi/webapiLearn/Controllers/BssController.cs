using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using webapiLearn.Models;
using webapiLearn.Models.BssModels;
using webapiLearn.Models.Data;
using System.Text.Json;


namespace webapiLearn.Controllers
{
  [ApiController]
  [Route("[controller]/api/")]
  public class BssController : ControllerBase
  {
    private readonly DapperStraightContext _dapperStraightContext;
    private readonly DapperStraightContextdqdb _dapperStraightContextdqdb;

    public BssController(DapperDbContext context, DapperStraightContext dapperStraightContext, DapperStraightContextdqdb dapperStraightContextdqdb)
    {
      _dapperStraightContext = dapperStraightContext;
      _dapperStraightContextdqdb = dapperStraightContextdqdb;
    }

    [HttpGet]
    [Route("carrier")]
    public async Task<List<Carrier>> GetListOfCarriers()
    {
      string query = @"
                            SELECT ""CarrierCode"",
                                   ""Name"",                                
                                   ""Id"" as ""BSSNetworkId""                                 
                            FROM dbo.""Networks""                                                        
                            ";


      using (var conStr = this._dapperStraightContext.CreateConnection())
      {
        var jj = await conStr.QueryAsync<Carrier>(query);
        //var jj = await _context.user.ToListAsync();
        return jj.ToList();
      }

      //https://localhost:7163/api/bss/productCatalog/carrier
    }

    [HttpGet]
    [Route("networks/{isActive}")]
    public async Task<OSNetworksGetResponse> GetNetworks(int isActive)
    {
      bool isActv = (isActive == 0 ? false : true);
      string isActvb = "";
      if (isActive == 0)
      {
        isActvb = "where n.\"IsActive\"=false";
      }
      else if (isActive < 0)
      {
        isActvb = "";
      }
      else
      {
        isActvb = "where n.\"IsActive\"=true";
      }

      string queryNetwork = @"
SELECT 
n.""Id"",
n.""Name"" 
,n.""Description""
,n.""LogoId""
,Logos.""Name"" as ""LogoName""
,Images.""ImageURL"" as ""LogoUrl""
,n.""IsActive""
from ""ProductCatalog"".dbo.""Networks"" n
left outer join ""ProductCatalog"".dbo.""Logos"" Logos on n.""LogoId"" = Logos.""Id"" 
left outer join ""ProductCatalog"".dbo.""Images"" Images on Images.""Id"" = Logos.""ImageId""
" + isActvb;

      string queryLogos = @"
SELECT 
logos.""Id""
,logos.""Name"" 
,logos.""ImageId""
,Images.""ImageURL"" as ""LogoUrl""
from ""ProductCatalog"".dbo.""Logos"" Logos
left outer join ""ProductCatalog"".dbo.""Images"" Images on Images.""Id"" = Logos.""ImageId""
";
      var os = new OSNetworksGetResponse();
      using (var conStr = this._dapperStraightContext.CreateConnection())
      {
        var res = await conStr.QueryAsync<OSNetworksGetResponse.NetworkItem>(queryNetwork, new { isActv });
        var res1 = await conStr.QueryAsync<OSNetworksGetResponse.LogoItem>(queryLogos);
        //var jj = await _context.user.ToListAsync();
        foreach (var networkItem in res)
        {
          os.Networks.Add(networkItem);
        }

        foreach (var logos in res1)
        {
          os.Logos.Add(logos);
        }
        return os;
      }

      //https://localhost:7163/api/bss/productCatalog/networks
    }

    [HttpGet]
    [Route("productClasses")]
    public async Task<ProductClassesResponseModel> GetProductClasses()
    {
      string query = @"
select 
""Id"" 
,""Name"" 
,""Description"" 
,""GLAccountNumber"" 
,""IsActive"" 
,""CreatedAt"" 
,""CreatedBy"" 
,""ModifiedAt"" 
,""ModifiedBy"" 
from ""ProductCatalog"".dbo.""ProductClasses"" pc
";

      using (var conStr = this._dapperStraightContext.CreateConnection())
      {
        var response = await conStr.QueryAsync<ProductClass>(query);

        return new ProductClassesResponseModel { ProductClasses = response.ToList() };
      }

      //https://localhost:7163/api/bss/productCatalog/productclasses
    }

    //        [HttpGet]
    //        [Route("productClasses/usercar")]
    //        public async Task<List<UserCar_Model>> GetCarsByUser()
    //        {
    //            string queryProductClasses = @"
    //select u.id,u.""name"",c.userid ,c.brand, c.model from dqdb.dbo.""user"" u 
    //inner join dqdb.dbo.cars c on u.id = c.userID
    //order by u.id asc, c.model asc;
    //";
    //            List<UserCar_Model> users = new List<UserCar_Model>();
    //            using (var conStr = this._dapperStraightContextdqdb.CreateConnection())
    //            {
    //                var response = await conStr.QueryAsync<UserCar_Model, Car, UserCar_Model>(sql:queryProductClasses,map:(u, c) =>
    //                {
    //                    //if its not true means if its false
    //                    if(!users.Any(x => x.id == c.userId)){
    //                        u.cars.Add(c);
    //                        users.Add(u);
    //                    }
    //                    else //if its true
    //                    {
    //                        users.Single(x => x.id == c.userId).cars.Add(c);
    //                    }
    //                    return null;

    //                },splitOn:"userid");

    //                return users;
    //            }

    //            //https://localhost:7163/api/bss/productCatalog/productclasses/usercar
    //        }

    [HttpGet]
    [Route("productClasses/productspecs")]
    public async Task<List<ProductSpecification>> GetProdSpecs(long productId)
    {
      string query = @"
Select
ps2.""Id"" ""ProductSpecificationId""
,ps2.""SpecificationTypeId"" 
,ps2.""ProductId""
,coalesce (mu.""Value"",'') ""Measurement""
,ps2.""MeasurementUnitId""
,coalesce(mu.""Value"", '') ""MeasurementName"" 
,coalesce(mu.""Abbreviation"",'') ""MeasurementAbbreviation""
,ps2.""IsActive"" 
,ps2.""SetBySKU"" 
,st.""Name"" ""SpecificationName""
,sdt.""Id"" ""DataTypeId""
,sdt.""Name"" ""DataTypeName""
,ps2.""CreatedAt"" 
,ps2.""CreatedBy"" 
,ps2.""ModifiedAt"" 
,ps2.""ModifiedBy""
--values
,psv.""Id"" ""ProductSpecificationValueId""
,psv.""ProductSpecificationId""
,psv.""Name"" 
,psv.""Value"" 
,psv.""IsActive"" 
,psv.""CreatedAt"" 
,psv.""CreatedBy"" 
--Asignments
,psa.""Id"" ""ProductSpecificationAssignmentId""
,psa.""SpecificationValueId"" 
,psv.""Name"" SpecificationName
,psv.""Value"" ""SpecificationValue""
,psa.""AssignToSpecificationValueId"" 
,psv.""Name"" ""AssignToSpecificationName""
,psv.""Value""  ""AssignToSpecificationValue""
,psa.""CreatedAt"" 
,psa.""CreatedBy"" 
from 
dbo.""ProductSpecifications"" ps2 inner join dbo.""SpecificationTypes"" st on ps2.""SpecificationTypeId"" = st.""Id"" 
inner join dbo.""SpecificationDataTypes"" sdt on sdt.""Id"" = st.""SpecificationDataTypeId"" 
left join dbo.""MeasurementUnits"" mu on mu.""Id"" = ps2.""MeasurementUnitId""
--Assignments
left join dbo.""ProductSpecificationValues"" psv on psv.""ProductSpecificationId"" = ps2.""Id"" 
left join dbo.""ProductSpecificationAssignments"" psa on (psa.""SpecificationValueId"" = psv.""Id"" and psv.""Id"" = psa.""AssignToSpecificationValueId"")
--left join dbo.""ProductSpecificationValues"" psv2 on psv2.""Id""  =  psa.""AssignToSpecificationValueId"" 
where ps2.""ProductId""  =  @productId
and ps2.""IsActive"" = true and psv.""IsActive"" = true
order by ps2.""SpecificationTypeId""  
";
      var res = new List<ProductSpecification>();
      using (var con = _dapperStraightContext.CreateConnection())
      {
        await con.QueryAsync<
            ProductSpecification,
            ProductSpecificationValue,
            ProductSpecificationAssignment,
            ProductSpecificationAssignment>(query,
            (spec, specValue, specAssignment) =>
            {
              if (spec != null && !res.Any(s => s.ProductSpecificationId == spec.ProductSpecificationId))
                res.Add(spec);
              var currSpec = res.FirstOrDefault(s => s.ProductSpecificationId == spec.ProductSpecificationId);
              if (specValue != null &&
                          !currSpec.ProductSpecificationValues.Any(
                              v => v.ProductSpecificationValueId == specValue.ProductSpecificationValueId))
                currSpec.ProductSpecificationValues.Add(specValue);
              var currValue = currSpec.ProductSpecificationValues.FirstOrDefault(v => v.ProductSpecificationValueId == specValue.ProductSpecificationValueId);
              if (specAssignment != null &&
                      !currValue.ProductSpecificationAssignments.Any(
                          a => a.ProductSpecificationAssignmentId == specAssignment.ProductSpecificationAssignmentId))
                currValue.ProductSpecificationAssignments.Add(specAssignment);
              return specAssignment;
            }
            , new { productId }, splitOn: "ProductSpecificationValueId, ProductSpecificationAssignmentId");

        return res.ToList();
      }

      //https://localhost:7163/api/bss/productCatalog/productclassesproductspecs
    }

    [HttpGet]
    [Route("productClasses/productpricing")]
    public async Task<GetProductPricingResponse> GetProductPricingForStagingPlanAndFeatures(long productId)
    {
      string query = @"
select
--ProductPricingConfiguration
ppc.""Id"" ""ProductPricingConfigurationId"" ,ppc.""PricingConfigurationId"" ,ppc.""PriceVariesBy""
--PurchasingOptions
,po.""Id"" ""PurchasingOptionId"", po.""Name"" , po.""Term""
--PricingBillingFrequency
,po.""BillingFrequencyId"", bf.""Name"" , bf.""Type""  
--OfferLevel
,ol.""Id"" ""OfferLevelId"", ol.""Name"" 
--itemsCatalog
,ic.""Id"" ""ItemCatalogId"", ic.""Price""
--SkuItem
,i.""Id"" ""ItemId"", i.""SKU""
--RateCard
from dbo.""ProductPricingConfigurations"" ppc 
inner join dbo.""Items"" i on i.""ProductId"" = ppc.""ProductId""  
inner join dbo.""ItemCatalogs"" ic on i.""Id"" = ic.""ItemId""
inner join dbo.""PurchasingOptions"" po on po.""Id"" = ic.""PurchasingOptionId""
inner join dbo.""BillingFrequencies"" bf on bf.""Id"" = po.""BillingFrequencyId""
inner join dbo.""OfferLevels"" ol on ol.""Id"" = ic.""OfferLevelId"" 
where ppc.""ProductId"" = @productId
and ol.""Is_Active"" = true
";
      var res = new GetProductPricingResponse();
      using (var con = _dapperStraightContext.CreateConnection())
      {
        await con.QueryAsync<
            GetProductPricingResponse.GetProductPricingConfiguration,
            GetProductPricingResponse.GetPricingPurchasingOptionItem,
            GetProductPricingResponse.PricingBillingFrequency,
            GetProductPricingResponse.GetPricingOfferLevel,
            GetProductPricingResponse.GetPricingItemStaging,
            GetProductPricingResponse.SkuItem,
            GetProductPricingResponse.GetProductPricingConfiguration>
           (query,
            (ppc, ppoi, pbf, pol, pis, si) =>
            {
              if (res.ProductPricingConfiguration == null)
              {
                res.ProductPricingConfiguration = ppc;
              }
              ;

              if (!res.PurchasingOptions.Any(x => x.PurchasingOptionId == ppoi.PurchasingOptionId))
              {
                ppoi.BillingFrequency = pbf;
                ppoi.OfferLevel = pol;
                res.PurchasingOptions.Add(ppoi);
              }
              var CurPurchasingOptions = res.PurchasingOptions.FirstOrDefault(x => x.PurchasingOptionId == ppoi.PurchasingOptionId);
              if (pis != null && !CurPurchasingOptions.ItemCatalogs.Any(x => x.ItemCatalogId == pis.ItemCatalogId))
              {
                pis.Items = si;
                CurPurchasingOptions.ItemCatalogs.Add(pis);
              }
              return ppc;
            }
            , new { productId }, splitOn: "PurchasingOptionId, BillingFrequencyId, OfferLevelId, ItemCatalogId, ItemId");

        return res;
      }

      //https://localhost:7163/api/bss/productCatalog/productclasses/productpricing
    }

    [HttpGet]
    [Route("bss/stagingproductpricing")]
    public async Task<GetStagingProductPricingResponse> GetStagingProductPricingForStagingPlanAndFeatures(long stagingProductId)
    {
      string query = @"
select
--ProductPricingConfigurationStaging
ppcs.""Id"" ,ppcs.""PricingConfigurationId"" ,ppcs.""PriceVariesBy""
--PurchasingOptions
,po.""Id"" , po.""Name"" , po.""Term""
--PricingBillingFrequency
,po.""BillingFrequencyId"" ""Id"", bf.""Name"" , bf.""Type""  
--OfferLevel
,ol.""Id"" , ol.""Name"" 
--itemsCatalog
,ics.""Id"" , ics.""Price"", ics.""FullPurchasePrice"" , ics.""InterestRate"" , ics.""PricingType"" 
--SkuItem
,is2.""Id"" , is2.""SKU""
--RateCard
from dbo.""ProductPricingConfigurationsStaging"" ppcs 
inner join dbo.""ItemsStaging"" is2 on is2.""StagingProductId"" = ppcs.""ProductStagingId""  
inner join dbo.""ItemCatalogStaging"" ics on ics.""itemsStagingId"" = is2.""Id""
inner join dbo.""PurchasingOptions"" po on po.""Id"" = ics.""PurchasingOptionId""
inner join dbo.""BillingFrequencies"" bf on bf.""Id"" = po.""BillingFrequencyId""
left join dbo.""OfferLevels"" ol on ol.""Id"" = ics.""OfferLevelId"" 
where ppcs.""ProductStagingId"" = @stagingProductId
and ol.""Is_Active"" = true

";
      var res = new GetStagingProductPricingResponse();
      using (var con = _dapperStraightContext.CreateConnection())
      {
        await con.QueryAsync<
            GetStagingProductPricingResponse.GetProductPricingConfigurationStaging,
            GetStagingProductPricingResponse.GetPricingPurchasingOptionItem,
            GetStagingProductPricingResponse.PricingBillingFrequency,
            GetStagingProductPricingResponse.GetPricingOfferLevel,
            GetStagingProductPricingResponse.GetPricingItemStaging,
            GetStagingProductPricingResponse.SkuItem,
            GetStagingProductPricingResponse.GetPricingItemStaging>
           (query,
            (ppc, ppoi, pbf, pol, pis, si) =>
            {
              if (res.ProductPricingConfigurationStaging == null)
              {
                res.ProductPricingConfigurationStaging = ppc;
              }
              ;

              if (!res.PurchasingOptions.Any(x => x.Id == ppoi.Id))
              {
                ppoi.BillingFrequency = pbf;
                ppoi.OfferLevel = pol;
                res.PurchasingOptions.Add(ppoi);
              }

              var CurPurchasingOptions = res.PurchasingOptions.FirstOrDefault(x => x.Id == ppoi.Id);
              if (pis != null && !CurPurchasingOptions.ItemCatalogStaging.Any(x => x.Id == pis.Id))
              {
                pis.ItemStaging = si;
                CurPurchasingOptions.ItemCatalogStaging.Add(pis);
              }
              return pis;
            }
            , new { stagingProductId }, splitOn: "Id");

        return res;
      }

      //https://localhost:7163/api/bss/productCatalog/productclasses/stagingproductpricing
    }

    [HttpGet]
    [Route("stagingspecifications")]
    public async Task<List<SpecificationStaging>> GetStagingSpecificationsByProductIdForStagingPlanAndFeatures(long productsStagingId)
    {

      string query = @"
select 
pss.""Id""
,pss.""ProductSpecificationId"" 
,pss.""SpecificationTypeId"" 
,pss.""ProductId"" 
,pss.""StagingProductId"" 
,pss.""MeasurementUnitId""
,pss.""IsActive"" 
,pss.""SetBySKU"" 
,sdt.""Id"" ""DataTypeId""
,sdt.""Name"" ""DataTypeName""
,pss.""IsPublished"" 
,pss.""PublishedAt"" 
,st.""Name"" ""SpecificationName""
,coalesce (mu.""Value"",'') ""Measurement""
,sdt.""Name"" ""Type""
--values
,psvs.""Id""
,psvs.""ProductSpecificationValuesId""
,psvs.""ProductSpecificationId""
,psvs.""ProdSpecStagingId"" 
,psvs.""Name"" 
,psvs.""Value"" 
,psvs.""IsActive"" 
,psvs.""IsPublished"" 
,psvs.""PublishedAt""  
--Asignments
,psas.""Id""
,psas.""ProdSpecAssignmentId"" 
,psas.""SpecificationValueId"" 
,psas.""AssignToSpecificationValueId""-- ""AssignToSpecificationValueId""
,psas.""IsPublished""  
from 
dbo.""ProductSpecificationsStaging"" pss 
inner join dbo.""SpecificationTypes"" st on pss.""SpecificationTypeId"" = st.""Id"" 
inner join dbo.""SpecificationDataTypes"" sdt on sdt.""Id"" = st.""SpecificationDataTypeId""
left join dbo.""MeasurementUnits"" mu on mu.""Id"" = pss.""MeasurementUnitId""
--Assignments
left join dbo.""ProductSpecificationValuesStaging"" psvs on psvs.""ProdSpecStagingId"" = pss.""Id""
left join dbo.""ProductSpecificationAssignmentsStaging"" psas on psas.""SpecificationValueId"" = psvs.""Id""
left join dbo.""ProductSpecificationValuesStaging"" psvs2 on psvs2.""Id"" = psas.""AssignToSpecificationValueId"" 
where pss.""StagingProductId"" =  @productsStagingId
and pss.""IsActive"" = true and psvs.""IsActive"" = true
order by pss.""Id"";  
";
      var res = new List<SpecificationStaging>();
      using (var con = _dapperStraightContext.CreateConnection())
      {
        await con.QueryAsync<
            SpecificationStaging,
            SpecificationValueStaging,
            SpecificationAssignmentStaging,
            SpecificationAssignmentStaging>(query,
            (spec, specValue, specAssignment) =>
            {
              if (spec != null && !res.Any(s => s.Id == spec.Id))
                res.Add(spec);
              var currSpec = res.FirstOrDefault(s => s.Id == spec.Id);
              if (specValue != null &&
                          !currSpec.ProductSpecificationValuesStaging.Any(
                              v => v.Id == specValue.Id))
                currSpec.ProductSpecificationValuesStaging.Add(specValue);
              var currValue = currSpec.ProductSpecificationValuesStaging.FirstOrDefault(v => v.Id == specValue.Id);
              if (specAssignment != null &&
                      !currValue.ProductSpecificationAssignmentsStaging.Any(
                          a => a.Id == specAssignment.Id))
                currValue.ProductSpecificationAssignmentsStaging.Add(specAssignment);
              return specAssignment;
            }
            , new { productsStagingId }, splitOn: "Id");

        return res;

        //https://localhost:7163/api/bss/productCatalog/bss/stagingSpecification
      }
    }

    [HttpGet]
    [Route("carriergroups")]
    public async Task<List<GetPlanAndFeaturesCarrierGroupsStagingResponseItem>> GetPlanAndFeaturesCarrierGroupsStaging(long productsStagingId)
    {

      string query = @"
SELECT 
pafcg.""Id"",
pafcg.""PlanAndFeatureCarrierGroupId"",
pafcg.""CarrierGroupId"",
cg.""Name"" ""CarrierGroup"",
pafcg.""ProductCarrierId"",
pafcg.""ProductCarriersStagingId"",
pafcg.""ProductId"",
pafcg.""ProductsStagingId"",
n.""CarrierCode"" ""ProductStagingCarrierCode"",
n.""Name"" ""ProductStagingCarrierName"",
pcs.""BSSNetworkId"" ""ProductStagingBSSNetworkId"",
pafcg.""Type"",
pafcg.""CreatedAt"" ,
pafcg.""CreatedBy"" ,
pafcg.""IsPublished"" ,
pafcg.""PublishedAt"" 
FROM dbo.""PlanAndFeatureCarrierGroupsStaging"" pafcg
INNER JOIN dbo.""CarrierGroups"" cg ON cg.""Id"" = pafcg.""CarrierGroupId""
LEFT join dbo.""ProductsStaging"" ps on ps.""Id"" = pafcg.""ProductsStagingId"" 
LEFT JOIN dbo.""ProductCarriersStaging"" pcs ON pcs.""Id"" = pafcg.""ProductCarriersStagingId""
LEFT JOIN dbo.""Networks"" n ON n.""Id"" = pcs.""BSSNetworkId""
WHERE pafcg.""ProductsStagingId"" = @productsStagingId;  
";
      using (var con = _dapperStraightContext.CreateConnection())
      {
        var result = await con.QueryAsync<GetPlanAndFeaturesCarrierGroupsStagingResponseItem>(query, new { productsStagingId });
        return result.ToList();
      }

      //https://localhost:7163/api/bss/productCatalog/bss/carrierGroups
    }

    [HttpGet]
    [Route("ProductByName")]
    public async Task<ValidateProductNameResponse> GetDraftProductByName(string productName)
    {
      string query =
@"SELECT 
""Name"" from dbo.""ProductsStaging"" ps 
where lower(""Name"") = lower(@productName)
limit 1;
";

      using (var connection = _dapperStraightContext.CreateConnection())
      {
        string? res = await connection.QueryFirstOrDefaultAsync<string>(query, new { productName });
        if (res != null)
        {
          return new ValidateProductNameResponse { IsValid = false };
        }
        else
        {
          return new ValidateProductNameResponse { IsValid = true };
        }
      }
    }

    [HttpGet]
    [Route("subcatsort/{id}")]
    public async Task<List<ProductSubcategoryViewModel>> GetSubcatsort(int id)
    {
      string query =
@"SELECT s.""Id"", 
s.""Name"", 
s.""Description"", 
""ProductCategoryId"", 
c.""Name"" ProductCategoryName,
s.""IsVisible"", 
""IsPromoted"", 
s.""RequireAddress"", 
s.""DefaultProductImageOptionId"", 
dpio.""Name"" DefaultProductImageOption,
CASE
	WHEN dpio.""Name"" = 'Custom' THEN 
		s.""CustomImageId""
	WHEN dpio.""Name"" = 'Category' THEN 
		c.""CustomImageId""
	WHEN dpio.""Name"" = 'Catalog' THEN
		null
END CustomImageId, 
CASE
	WHEN dpio.""Name"" = 'Custom' THEN 
		isc.""ImageURL""
	WHEN dpio.""Name"" = 'Category' THEN 
		ic.""ImageURL""
	WHEN dpio.""Name"" = 'Catalog' THEN 
		null
END CustomImageUrl,
s.""Order""
FROM dbo.""ProductSubcategories"" s
JOIN dbo.""ProductCategories"" c ON c.""Id"" = s.""ProductCategoryId""
LEFT JOIN dbo.""DefaultProductImageOptions"" dpio ON dpio.""Id"" = s.""DefaultProductImageOptionId""
LEFT JOIN dbo.""Images"" isc ON isc.""Id"" = s.""CustomImageId""
LEFT JOIN dbo.""Images"" ic ON ic.""Id"" = c.""CustomImageId""
WHERE ""ProductCategoryId"" = @id
ORDER BY ""ProductCategoryId"", ""Id"";
";

      using (var connection = _dapperStraightContext.CreateConnection())
      {
        var res = await connection.QueryAsync<ProductSubcategoryViewModel>(query, new { id });
        var sortorder = res.OrderBy(sub => sub.Order);
        return res.ToList();
      }
    }

    [HttpGet]
    [Route("NullTypes")]
    public async Task<string> GetNullTypes(int id)
    {
      var ccl = await GetNullTypesDB(id);
      var test = true;
      string ifcond = "If condition - It has a boolean values of ";
      string elsecond = "else condition - It has a boolean values of ";
      string returnMessage = "";

      if (!ccl && test)
      {
        returnMessage = string.Concat(ifcond, ccl);
        Console.WriteLine(returnMessage);
      }
      else
      {
        returnMessage = string.Concat(elsecond, ccl);
        Console.WriteLine(returnMessage);
      }

      return JsonSerializer.Serialize(new { boolvalue = returnMessage });
    }

    private async Task<bool> GetNullTypesDB(int id)
    {
      string query =
@"SELECT 
coalesce(smokes,false) as smokes from dbo.nulltypes where id = @id;
";

      using (var connection = _dapperStraightContextdqdb.CreateConnection())
      {
        var res = await connection.QueryFirstOrDefaultAsync<bool>(query, new { id });

        return res;
      }

    }
    

    [HttpGet]
    [Route("clientvisibitity", Name = "http://localhost:5261/bss/api/clientvisibitity?clientId=9994&ProductCategoryId=2556")]
            public async Task<bool> GetClientVisibilitySettingByProductCategoryId(int clientId, long productCategoryId)
    {
      string query = @"
select *
from dbo.""ClientVisibilitySettings""
where ""ClientId"" = @clientId
and ""ProductCategoryId"" = @productCategoryId";

      using (var connection = _dapperStraightContext.CreateConnection())
      {
        var res = await connection.QueryFirstOrDefaultAsync<bool>(query, new { clientId, productCategoryId });
        return res;
      }
    }

  }
}
