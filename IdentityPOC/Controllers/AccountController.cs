using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityPOC.Data.DALs;
using IdentityPOC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPOC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            TempData["Message"] = "Wylogowano Użytkownika";
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Register()
        {
            var vm = new RegisterViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(vm.KodKreskowy);
                if(user == null)
                {
                    user = new AppUser()
                    {
                        UserName = vm.KodKreskowy,
                        KodKreskowy = vm.KodKreskowy,
                        Imie = vm.Imie,
                        Nazwisko = vm.Nazwisko,
                        Stanowisko = vm.Stanowisko
                    };
                    var res = await _userManager.CreateAsync(user, vm.Haslo);
                    if (res.Succeeded)
                    {
                        TempData["Message"] = $"Zarejestrowano użytkownika: '{user.ImieNazwisko}'";
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        ViewBag.Message = $"Błędy: {res.Errors}";
                        return View(vm);
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["Message"] = ex.Message;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var vm = new LoginViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.KodKreskowy);
            if(user != null)
            {
                var res = await _signInManager.PasswordSignInAsync(user, vm.Haslo, true, false);

                if (res.Succeeded)
                {
                    TempData["Message"] = $"Zalogowano jako: {user.ImieNazwisko}";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Niepoprawne hasło dla danego użytkownika";
                    return View(vm);
                }
            }

            ViewBag.Message = "Niepoprawny login";
            return View(vm);
        }
    }
}
