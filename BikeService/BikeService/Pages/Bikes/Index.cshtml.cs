using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Repositories;
using BikeService.Services.interfaces;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.Bikes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly BikeServiceDbContext _db;

        private readonly IBikesService _bikesService;

        public IndexModel(BikeServiceDbContext db,IBikesService bikesService)
        {
            _db = db;
            _bikesService = bikesService;
        }

        [BindProperty]
        public BikeAndCustomerViewModel BikeAndCustomVM { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult OnGet(string userId = null)
        {
            

            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            var bikesToView = _bikesService.GetAllById(userId);
            var applicationUser = _db.Users.FirstOrDefault(x => x.Id == userId);

            BikeAndCustomVM = new BikeAndCustomerViewModel()
            {
                Bikes = bikesToView.Select(x => x.ToViewModel()).ToList(),
                UserObj = applicationUser.ToViewModel()
            };

            return Page();
        }
    }
}
