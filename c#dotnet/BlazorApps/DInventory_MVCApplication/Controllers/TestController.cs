using DInventory_Models;
using Microsoft.AspNetCore.Mvc;

namespace DInventory_MVCApplication.Controllers
{
    public class TestController : Controller
    {
        public ViewResult Index()
        {
            //string val = $"Id passed is {id}";
            BusParents busParents = new BusParents();
            busParents.BusParentName = "WriterCorporation";
            return View(busParents); //View(val.ToString());
        }

        [HttpPost]
        public ViewResult Index(BusParents bp)
        {
            //string val = $"Id passed is {id}";
            return View();
        }

        public string GetAddress(int id, string address)
        {
            string val = $"Id passed is {id} and Address is {address}";
            return val; //View(val.ToString());
        }
    }
}
