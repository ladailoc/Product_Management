using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Models;
using ProductManagement.Services;

namespace ProductManagement.Pages
{
    public class ProductPageModel : PageModel
    {
        public List<Product> products = null;
        public List<Product> listSearch= null;
        public Product product;
        [BindProperty]
        public string searchName { get; set; } = string.Empty;
        ProductService _productService;
        public ProductPageModel(ProductService productService)
        {
            _productService = productService;
            products = _productService.GetProducts();
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                ViewData["Title"] = $"Thông tin sản phẩm (ID = {id.Value})";
                product = _productService.GetProductById(id.Value);
            }
            else
            {
                ViewData["Title"] = $"Danh sách sản phẩm";
            }
        }
        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = "Sản phẩm cuối";
            product = _productService.GetProducts().LastOrDefault();
            if (product != null)
            {
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult OnGetRemoveAll()
        {
            products.Clear();
            return RedirectToPage("ProductPage");
        }
        public IActionResult OnGetLoadAll()
        {
            _productService.LoadProducts();
            return RedirectToPage("ProductPage");
        }
        public void OnPostSearch()
        {
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                products = products.Where(p => p.Name.Contains(searchName, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                products = _productService.GetProducts();
            }
        }
        public IActionResult OnPostUpdate(int id, string name, string description, decimal price)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                product.Name = name;
                product.Description = description;
                product.Price = price;
            }
            return RedirectToPage();
        }
        public IActionResult OnPostDelete(int id)
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToPage();
        }
    }
}
