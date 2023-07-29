using BLL.Abstract;
using Common.Auth;
using Entity.PModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlicisindanApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(PmLogin param)
        {
            var user = _loginService.Login(param);

            if (user is not null)
            {
                var ClaimsPrincipal = AuthHelper.GetClaimsPrincipal(
                    new AuthModel()
                    {
                        Name = user.Name,
                        NameIdentifier = user.Id.ToString()
                    }
                );

                await HttpContext.SignInAsync(ClaimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Wrong Email or Password";
                return PartialView();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Denied()
        {
            return PartialView();
        }
    }
}
