using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpryStore.BusinessLayer.Abstract;
using SpryStore.BusinessLayer.Concrete;
using SpryStore.DataAccessLayer.Abstract;
using SpryStore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace SpryStore.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.GetProductListWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetList().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.value = categories;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.Insert(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);
            _productService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.GetList().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.value = categories;

            var value = _productService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");
        }

        public IActionResult GetLast4Products()
        {
            var values = _productService.GetLast4Product();
            return View(values);
        }
    }
}
