using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Services.interfaces;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.Bikes
{
    public class DeleteModel : PageModel
    {
        private readonly IBikesService _bikesService;

        public DeleteModel(IBikesService bikesService)
        {
            _bikesService = bikesService;
        }

        [BindProperty]
        public BikeViewModel Bike { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult OnGet(int id)
        {
            var bikeToDelete = _bikesService.GetById(id);

            Bike = bikeToDelete.ToViewModel();

            if (Bike == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Bike == null)
            {
                return NotFound();
            }

            var userId = Bike.UserId;

            var bikeForRemove = Bike.ToDomainModel();
            _bikesService.Remove(bikeForRemove);

            StatusMessage = "Bike deleted successfully.";
            return RedirectToPage("./Index", new { userId });
        }
    }
}
