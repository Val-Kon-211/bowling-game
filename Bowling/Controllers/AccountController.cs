using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication7.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using TryTwo.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using DAL;
using Entity;

namespace WebApplication7.Controllers
{
    public class AccountController : Controller
    {
        private DBContext db;

        public AccountController(DBContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            //System.Diagnostics.Debug.WriteLine("I am Account/Login/Get");
            return View();
        }

        private static SHA512 hashAlgo = SHA512.Create();

        private static byte[] GetStringHash(string s)
        {
            if (s == null)
                return null;
            byte[] hash = hashAlgo.ComputeHash(Encoding.Unicode.GetBytes(s));
            return hash;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //System.Diagnostics.Debug.WriteLine("I am Account/Login/Post");
            if (ModelState.IsValid)
            {
                Users user = db.Users.First(u => u.Name == model.Name 
                                                 && u.Password.SequenceEqual(GetStringHash(model.Password)));
                if (user != null)
                {
                    await Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Lobby", "Bowling");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private void DebugUserOutput()
        {
            foreach (var anotherUser in db.Users)
            {
                string str = "";
                foreach (var byt in anotherUser.Password)
                {
                    str += byt;
                }
                System.Diagnostics.Debug.WriteLine(str);
                System.Diagnostics.Debug.WriteLine(anotherUser.Id);
                System.Diagnostics.Debug.WriteLine(anotherUser.Name);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await db.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                if (user == null)
                {
                    // + пользователя в бд
                    db.Users.Add(new Users { Name = model.Name, Password = GetStringHash(model.Password) });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Lobby", "Bowling");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
