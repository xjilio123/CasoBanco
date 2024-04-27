using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CasoBanco.Controllers
{
    [Route("[controller]")]
    public class Registro : Controller
    {
        private readonly ILogger<Registro> _logger;

        public Registro(ILogger<Registro> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModelList = new List<dynamic>();

            foreach (var user in users)
            {
                var userViewModel = new
                {
                    Id = user.Id,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    CreatedOn = user.CreatedOn,
                    ModifiedOn = user.ModifiedOn
                };

                viewModelList.Add(userViewModel);
            }

            return View(viewModelList);
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public object? ModifiedOn { get; internal set; }
        public object? CreatedOn { get; internal set; }
    }
}