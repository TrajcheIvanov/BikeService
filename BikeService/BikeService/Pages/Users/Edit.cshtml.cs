using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Repositories;
using BikeService.Utility;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly BikeServiceDbContext _db;
        public EditModel(BikeServiceDbContext db)
        {

            _db = db;
        }

        [BindProperty]
        public ApplicationUserViewModel AplicationViewModel { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            var modelForEdit = _db.Users.FirstOrDefault(x => x.Id == id);
            AplicationViewModel = modelForEdit.ToViewModel();

            if (AplicationViewModel == null)
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
            else
            {
                var modelForEdit = _db.Users.FirstOrDefault(x => x.Id == AplicationViewModel.Id);
                if (modelForEdit == null)
                {
                    return NotFound();
                }
                else
                {
                    modelForEdit.Name = AplicationViewModel.Name;
                    modelForEdit.PhoneNumber = AplicationViewModel.PhoneNumber;
                    modelForEdit.Address = AplicationViewModel.Address;
                    modelForEdit.City = AplicationViewModel.City;
                    modelForEdit.PostalCode = AplicationViewModel.PostalCode;

                    _db.SaveChanges();
                    return RedirectToPage("Index" , new { successMessage = $"Successfully edited User with name: {AplicationViewModel.Name}" });
                }
            }
        }

    }
}
