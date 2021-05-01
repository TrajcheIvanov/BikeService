using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Services.interfaces;
using BikeService.Utility;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly IServiceTypesService _serviceTypeService;
        public EditModel(IServiceTypesService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [BindProperty]
        public ServiceTypeViewModel ServiceType { get; set; }

        public IActionResult OnGet(int id)
        {
            var modelForEdit = _serviceTypeService.GetById(id);
            if (modelForEdit == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ServiceType = modelForEdit.ToViewModel();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var modelForUpdate = ServiceType.ToDomainModel();
                _serviceTypeService.Update(modelForUpdate);
                return RedirectToPage("Index", new { successMessage = $"Successfully Edited service type with name: {ServiceType.Name}" });
            }
        }
    }
}
