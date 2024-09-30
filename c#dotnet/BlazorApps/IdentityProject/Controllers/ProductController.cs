using IdentityProject.Data;
using IdentityProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace IdentityProject.Controllers
{    
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> ViewRes()
        {

            var products = await (from p in context.db_Product.Where(x => x.Enabled == true)
                                  join u in context.db_UsersIdentity on p!.CreUser.Id equals u.Id into pu

                                  from address in pu.DefaultIfEmpty()

                                  select new Product_ProductListViewModel()
                                  {
                                      ProductID = p.Id,
                                      ProductName = p.Product,
                                      CreatedDate = Convert.ToDateTime(p.CreatedDate),
                                      CreatedBy = address != null ? address.Email : "NA"
                                  }).ToListAsync();


            var ctrl = ControllerContext.ActionDescriptor.ControllerName;
            var act = ControllerContext.ActionDescriptor.ActionName;
            ViewBag.Controller = ctrl;
            ViewBag.Action = act;
            return View(products);

           
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Success = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Master_ProductCreateViewModel model)
        {
            var userID = Convert.ToInt32(HttpContext.User.FindFirst("UserID").Value);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var productExists = context.db_Product.Where(c => c.Product == model.Product).FirstOrDefault();

                if(productExists != null)
                {  
                    //ModelState.Clear();
                    ModelState.AddModelError("", "Product already exists");
                    return View(model);
                }

                var addProduct = new Master_Product
                {
                    Product = model.Product,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userID,
                    Enabled = true
                };

                var presult = await context.db_Product.AddAsync(addProduct);
                var result = await context.SaveChangesAsync();

                if(result > 0)
                {
                    var ID = addProduct.Id;
                    ViewBag.Success = true;
                    ViewBag.ID = ID;
                    ModelState.Clear();
                }
                return View();
            }
               
         }


    }
    
}

