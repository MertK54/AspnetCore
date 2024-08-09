using System.Security.Claims;
using BloggApp.Data.Abstract;
using BloggApp.Entity;
using BloggApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly EmailService _emailService;

        public UsersController(IUserRepository userRepository, EmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Posts");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    ModelState.AddModelError("", "Lütfen geçerli bir e-posta adresi girin.");
                    return View(model);
                }

                var userExists = await _userRepository.Users
                    .AnyAsync(x => x.UserName == model.UserName || x.Email == model.Email);

                if (!userExists)
                {
                    var verificationCode = _emailService.GenerateVerificationCode();

                    var user = new User
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Image = "avatar.jpg",
                        VerificationCode = verificationCode
                    };

                    _userRepository.SaveUser(user);

                    _emailService.SendVerificationCode(model.Email, verificationCode);
                    return RedirectToAction("VerifyCode", new { email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ya da e-posta zaten kullanımda.");
                }
            }
            return View(model);
        }

        public IActionResult VerifyCode(string email)
        {
            var model = new VerifyCodeViewModel
            {
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users
                    .FirstOrDefaultAsync(x => x.Email == model.Email);

                if (user != null && user.VerificationCode == model.Code)
                {
                    user.IsVerified = true;
                    _userRepository.SaveUser(user);

                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Doğrulama kodu geçersiz.");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users
                    .FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

                if (user != null)
                {
                    if (!user.IsVerified)
                    {
                        ModelState.AddModelError("", "E-posta adresinizi doğrulamadınız. Lütfen e-posta adresinize gönderilen kodu kullanarak doğrulama işlemini tamamlayın.");
                        return View(model);
                    }

                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName ?? ""),
                        new Claim(ClaimTypes.GivenName, user.Name ?? ""),
                        new Claim(ClaimTypes.UserData, user.Image ?? "")
                    };

                    if (user.Email == "altayturan@gmail.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Posts");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }

            return View(model);
        }

        public IActionResult Profile(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }

            var user = _userRepository
                .Users
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .ThenInclude(x => x.Post)
                .FirstOrDefault(x => x.UserName == username);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
