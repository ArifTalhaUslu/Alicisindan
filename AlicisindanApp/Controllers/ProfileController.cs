using BLL.Abstract;
using DataAccess.Repositories.Abstract;
using Entity.Models;
using Entity.VModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlicisindanApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserService _userService;
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProfileController(IUserService userService, IProductService productService, ICategoryService categoryService)
        {
            _userService = userService;
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int? POI)
        {
            AppUser? ProfileUser = null;
            var ActiveUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (POI.HasValue) ProfileUser = _userService.GetUser(new Entity.PModels.PmGetUser(){Id = POI.Value }).First();
            else ProfileUser = _userService.GetUser(new Entity.PModels.PmGetUser() { Id = ActiveUserId }).First();

            var Products = _productService.GetUsersProduct(ProfileUser.Id);

            var model = new VmProfile()
            {
                ProfileOwner = ProfileUser,
                Products = Products,
                Categories = _categoryService.GetCategories(),
                isUserAuthorizedForThisPage = (ProfileUser.Id == ActiveUserId)
            };

            return View(model);
        }
    }
}
