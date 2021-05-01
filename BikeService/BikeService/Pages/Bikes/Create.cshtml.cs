using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Services.interfaces;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.Bikes
{
    public class CreateModel : PageModel
    {
        
        private readonly IBikesService _bikesService;

        public CreateModel(IBikesService bikesService)
        {
            _bikesService = bikesService;
        }

        [BindProperty]
        public BikeViewModel Bike { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult OnGet(string userId=null)
        {
            Bike = new BikeViewModel();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            Bike.UserId = userId;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _bikesService.Create(Bike.ToDomainModel());
                StatusMessage = "Bike has been added sucessfully";
                return RedirectToPage("./Index", new { userId = Bike.UserId});
            }

            return Page();
        }
        
    }
}
