using DInventory_MVCApplication.Models;
using DInventory_MVCApplication.Models.BusEntities;
using Microsoft.AspNetCore.Mvc;

namespace DInventory_MVCApplication.Controllers
{
    public class BusEntitiesController : Controller
    {
        public ApplicationDataContext _db;

        public BusEntitiesController(ApplicationDataContext dbCon)
        {
            this._db = dbCon;
        }

        public IActionResult Index()
        {
            var Parent = _db.busParents.ToList();
            var Chilren = _db.busChildren.ToList();

            var busEntitiesView = new BusEntitiesVM
            {
                busParents = Parent,
                busChildrens = Chilren
            };
            return View(busEntitiesView);
        }
    }
}
