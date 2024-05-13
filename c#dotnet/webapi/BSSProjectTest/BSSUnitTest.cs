using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using RestSharp;
using webapiLearn.Controllers;
using webapiLearn.Models.Data;

namespace BSSProjectTest
{
    public class BSSUnitTest
    {        
        
        [SetUp]
        public void Setup()
        {
            //Arrange            
        }

        [Category("mb2_3837")]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task GetNetworksTest(int isActive)
        {
            var baseUrl = $"https://localhost:7163/api/bss/productCatalog/networks/{isActive}";
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest);            
            Assert.That(restResponse != null);
            //Assert.That(restResponse.Content.Contains("Networks") != null);
            //Assert.That(restResponse.Logos != null);
            //Assert.Pass();
        }
    }
}