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
    public class EditModel : PageModel
    {
        private readonly IBikesService _bikesService;

        public EditModel(IBikesService bikesService)
        {
            _bikesService = bikesService;
        }

        [BindProperty]
        public BikeViewModel Bike { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult OnGet(int id)
        {
            
            var bikeToEdit = _bikesService.GetById(id);

            Bike = bikeToEdit.ToViewModel();

            if (Bike == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bikeForUpdate = Bike.ToDomainModel();
            _bikesService.Update(bikeForUpdate);

            StatusMessage = "Bike updated successfully.";
            return RedirectToPage("./Index", new { userId = Bike.UserId });
        }
    }
}
