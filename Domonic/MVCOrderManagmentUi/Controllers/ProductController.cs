using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCOrderManagmentUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly GSparkShopDBContext _context;
        public ProductController(GSparkShopDBContext context)
        {
            _context = context;
        }
        public IActionResult ViewProducts(string filterby, bool? des)
        {
            List<Product> Results = new List<Product>();
            switch (filterby)
            {
                case "none":
                    Results = _context.Products.ToList();
                    break;
                case "prodname":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdName).ToList();
                        break;
                    }
                    else 
                    {
                        Results = _context.Products.OrderBy(x => x.ProdName).ToList();
                        break;
                    }  
                case "prodprice":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdPrice).ToList();
                        break;
                    }
                    else
                    {
                        Results = _context.Products.OrderBy(x => x.ProdPrice).ToList();
                        break;
                    }
                case "prodtype":
                    if (des == true)
                    {
                        Results = _context.Products.OrderByDescending(x => x.ProdType).ToList();
                        break;
                    }
                    else
                    {
                        Results = _context.Products.OrderBy(x => x.ProdType).ToList();
                        break;
                    }
                default:
                    Results = _context.Products.ToList();
                    break;
            }
            return View(Results);
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct([FromForm]string prodName, [FromForm] decimal prodPrice, [FromForm] string prodType)
        {
            _context.Products.Add(new Product
            {
                ProdName = prodName,
                ProdPrice = prodPrice,
                ProdType = prodType
            });
            _context.SaveChanges();
            return RedirectToAction("ViewProducts",routeValues: new {filterby = "none"});
        }
        public async Task<IActionResult> DeleteProduct(int? prodId)
        {
            var productToBeDeleted = await _context.Products.FirstOrDefaultAsync(x=>x.ProdId == prodId);
            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProducts", routeValues: new { filterby = "none" });
        }
    }
}
