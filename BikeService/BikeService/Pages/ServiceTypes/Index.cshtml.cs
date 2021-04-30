using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Services.interfaces;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeService.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {
        private readonly IServiceTypesService _serviceTypeService;
        public IndexModel(IServiceTypesService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        public List<ServiceTypeViewModel> ServiceTypes { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet(string successMessage)
        {
            SuccessMessage = successMessage;
            var serviceTypes = _serviceTypeService.GetAll();
            ServiceTypes = serviceTypes.Select(x => x.ToViewModel()).ToList();
        }
    }
}
