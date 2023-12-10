using Business.Abstract;
using Business.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AuthContoller : Controller
    {
        IAuthService _authService;

        public AuthContoller(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return Redirect(nameof(Login));
        }

        [HttpGet("Login")]
        public IActionResult Login(string? ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginModel model)
        {
            string returnUrl = TempData["ReturnUrl"].ToString();

            var userLoginDto = new UserLoginDto() {Email = model.Email, Password = model.Password, RememberMe = model.RememberMe };

            var result = await _authService.LoginAsync(userLoginDto);

            if (result.Success)
                return LocalRedirect(returnUrl);

            else
            {
                ViewBag.ErrorMessage = result.Message;
            }

            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Şifreler aynı olmalı";
                return View(model);
            }

            UserRegisterDto user = new()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };

            var result = await _authService.RegisterAsync(user);

            if (result.Success)
                return RedirectToAction(nameof(Login));

            else
            {
                ViewBag.ErrorMessage = result.Message;
            }

            return View();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
