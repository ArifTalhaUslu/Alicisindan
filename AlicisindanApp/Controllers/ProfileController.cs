using BLL.Abstract;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlicisindanApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserService _userService;
        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var usrId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser? ActiveUser = _userService.GetUser(new Entity.PModels.PmGetUser() { Id = usrId }).First();

            return View();
        }
    }
}
