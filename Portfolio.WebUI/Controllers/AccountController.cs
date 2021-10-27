using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortFfoliodetask.Model.Memberships;
using Portfolio.WebUI.Models.DataContext;
using Portfoliotask.AppCode.Extension;
using Portfoliotask.Model.FormModel;
using Riodetask.AppCode.Extension;
using System;
using System.Threading.Tasks;

namespace Riodetask.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly ResumeDbContext db;
        readonly UserManager<PortfolioUser> userManager;
        readonly SignInManager<PortfolioUser> signinManeger;
        readonly IConfiguration configuraton;
        public AccountController(ResumeDbContext db, UserManager<PortfolioUser> userManager,
            SignInManager<PortfolioUser> signinManeger,
            IConfiguration configuraton)
        {
            this.db = db;
            this.userManager = userManager;
            this.signinManeger = signinManeger;
            this.configuraton = configuraton;
        }


        
        public async Task<IActionResult> logout()
        {
            await signinManeger.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        
        public IActionResult signin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signin(LoginFormModel user)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
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
                //User rolu olmayani Riodeye buraxmir!!
                //if (!await userManager.IsInRoleAsync(foundedUser, "User"))
                //{
                //    ViewBag.Message("Ad ve ya sifre sehvdir");
                //    return View(user);
                //}


                var sResult = await signinManeger.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (sResult.Succeeded != true)
                {
                    ViewBag.Message = "Ad ve ya sifre sehvdir!";
                    return View(user);
                }
                return RedirectToAction("index", "Home");

                //eger loginnen evvel hansisa sehifede imiwse loginnen sora ora atmag ucun

                var redirectUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (ModelState.IsValid)
            {

                var user = new PortfolioUser();
                user.FullName = model.FullName;
                user.UserName = model.UserName;
                //user.EmailConfirmed = true; // tesdiq yazmwiwam
                user.Email = model.Email;


                string token = $"subscribetoken-{model.UserName}-{DateTime.Now:yyyyMMddHHmmss} ";
                string hashtoken = token.Encrypt("BAHMAN");
                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={hashtoken}";

                var mailSent = configuraton.SendEmail(user.Email, "Riode", $"Please confirm your Email through this <a href={path}>link</a>");

                var result = await userManager.CreateAsync(user , model.Password);
                if (result.Succeeded)
                { 
                    ViewBag.Message = "Qeyde Alindi";
                    return RedirectToAction(nameof(signin));
                }
                 foreach (var error in result.Errors)
                 {
                    ModelState.AddModelError(error.Code,error.Description);
                 }
            }
                return View(model);

        }
    }


}
