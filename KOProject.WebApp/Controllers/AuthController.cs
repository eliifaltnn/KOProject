using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KOProject.WebApp.Models;
using KOProject.Data.Entity;
using KOProject.Data;
using KOProject.WebApp.Helpers;
namespace KOProject.WebApp.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private KoDbContext _ctx;
        public AuthController(KoDbContext db) : base("Auth", db)
        {
            this._ctx = db;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.LoginError = "";

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([Bind] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string errorMessage = "";
                User appUser = this._ctx.Users.FirstOrDefault(s => s.Username == model.Username && s.Password == model.Password);

                if (appUser != null)
                {
                    var userClaims = new List<Claim>();

                    var authProps = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    };

                    var userPrincipal = new ClaimsPrincipal(new[] { new ClaimsIdentity(userClaims, Names.AuthenticationType) });

                    await HttpContext.SignInAsync(userPrincipal, authProps);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                }
            }

            ViewBag.LoginError = "Hatalı giris yaptınız !";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
