using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Repositories;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly BikeServiceDbContext _db;
        public DeleteModel(BikeServiceDbContext db)
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
            var modelForDelete = _db.Users.FirstOrDefault(x => x.Id == AplicationViewModel.Id);

            _db.Users.Remove(modelForDelete);
            _db.SaveChanges();

            return RedirectToPage("Index" , new { successMessage = $"Successfully deleted User with name: {AplicationViewModel.Name}" });
        }
    }
}
