using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortFfoliodetask.Model.Memberships;
using Portfolio.WebUI.Models.DataContext;
using Portfoliotask.Model.FormModel;
using Riodetask.AppCode.Extension;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portfoliotask.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]

    public class AccountController : Controller
    {
        readonly UserManager<PortfolioUser> userManager;
         readonly SignInManager<PortfolioUser> signinManeger;
        readonly ResumeDbContext db;
        private Microsoft.AspNetCore.Identity.SignInResult sResult;

        public AccountController(UserManager<PortfolioUser> userManager,
            SignInManager<PortfolioUser> signinManeger , ResumeDbContext db)
        {
            this.userManager = userManager;
            this.signinManeger = signinManeger;
            this.db = db;

        }

        [AllowAnonymous]
        public IActionResult signin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> signin(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                PortfolioUser foundedUser = null;
                if (user.UserName.IsEmail())
                {
                    foundedUser = await userManager.FindByEmailAsync(user.UserName);
                }
                else
                {
                    foundedUser = await userManager.FindByNameAsync(user.UserName);
                }
                if (foundedUser == null)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }
                //Userin bashqa rolunun olub olmamagin yoxlayirig, admin panele girmek ucn
                var rIds = db.UserRoles.Where(u => u.UserId == foundedUser.Id).Select(u => u.RoleId).ToArray();//Role idlerin tapriq
                var HasAnotherRole = db.Roles.Where(r => !r.Name.Equals("User") && rIds.Contains(r.Id)).Any();//basqa rolun olmagini tapriq
                if (HasAnotherRole == false)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }

               
              var sResult =  await signinManeger.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (sResult.Succeeded !=true)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }
                return RedirectToAction("index", "home");
            }
            return View(user);
        }


        public async Task<IActionResult> logout()
        {
            await signinManeger.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
       
        [Route("/accessdenied.html")]
        public IActionResult accessdenied()
        {
            return View();
        }
    }
}
