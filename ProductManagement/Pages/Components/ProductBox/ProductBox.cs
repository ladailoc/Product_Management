using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Pages.Components.ProductBox
{
    public class ProductBox : ViewComponent
    {
        //public IViewComponentResult Invoke()
        //{
        //    //return View("_Default", products);
        //    return View<List<Product>>("_Default", products);
        //}

        List<Product> products = null;
        public ProductBox(ProductService productService)
        {
            products = productService.GetProducts();
        }
        public async Task<IViewComponentResult> InvokeAsync(bool sapXepTang = true) 
        {
            List<Product> _products = null;
            if (sapXepTang)
            {
                _products = products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _products = products.OrderByDescending(p => p.Price).ToList();
            }
            return View<List<Product>>(_products);
        }
    }
}
