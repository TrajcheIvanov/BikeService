using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Models;
using BikeService.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly BikeServiceDbContext _db;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            BikeServiceDbContext db
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            public string Name { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string PostalCode { get; set; }

            public string Email { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userFromDb = _db.Users.FirstOrDefault(x => x.Email == user.Email);

            Username = userFromDb.UserName;

            Input = new InputModel
            {
                PhoneNumber = userFromDb.PhoneNumber,
                Email = userFromDb.Email,
                Address = userFromDb.Address,
                City = userFromDb.City,
                Name = userFromDb.Name,
                PostalCode = userFromDb.PostalCode,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userFromDB = _db.Users.FirstOrDefault(x => x.Email == user.Email);

            userFromDB.Name = Input.Name;
            userFromDB.Address = Input.Address;
            userFromDB.City = Input.City;
            userFromDB.PostalCode = Input.PostalCode;
            userFromDB.PhoneNumber = Input.PhoneNumber;

            _db.SaveChanges();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
