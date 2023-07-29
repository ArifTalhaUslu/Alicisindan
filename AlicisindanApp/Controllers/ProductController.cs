using BLL.Abstract;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlicisindanApp.Controllers
{
    public class ProductController : Controller
    {
        private IUserService _userService;
        private IProductService _productService;
        public ProductController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Get(int id)
        {
            var model = _productService.GetProductById(id);
            return RedirectToAction("Index","Profile");
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            var ActiveUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            product.OwnerId = ActiveUserId;
            _productService.AddProduct(product);

            return RedirectToAction("Index", "Profile");
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("Index", "Profile");
        }
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index", "Profile");
        }
    }
}
