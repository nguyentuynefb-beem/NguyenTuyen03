using Microsoft.AspNetCore.Mvc;
using NguyenTuyen03.Models;

namespace NguyenTuyen03.Controllers
{
    public class ProductController : Controller
    {
        // Giả lập "cơ sở dữ liệu trong bộ nhớ"
        private static List<Product> _products = new List<Product>
        {

        new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "Powerful laptop" },
        new Product { Id = 2, Name = "Mouse", Price = 499.99m, Description = "Wireless mouse" },
        new Product { Id = 3, Name = "Keyboard", Price = 599.99m, Description = "Mechanical keyboard" }
        };
        public IActionResult Index()
        {
            return View(_products);
        }
        //hien thi chi tiet san pham
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Hien thi form tao san pham moi
        public IActionResult Create()
        {
            return View();
        }
        // xu ly du lieu form tao san pham moi
        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            _products.Add(newProduct);
            return RedirectToAction("Index");
        }
        // sua du lieu
        public IActionResult Edit(int Id)
        {
            var product = _products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
                return NotFound();
            return View(product);
        }
        // Nhận dữ liệu sau khi sửa 
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id ==
            updatedProduct.Id);
            if (product == null)
                return NotFound();
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            return RedirectToAction(nameof(Index));
        }
        //xu ly xoa san pham
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return RedirectToAction("Index");
        }
        //xac nhan xoa san pham
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
