using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Models;
using BikeService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly BikeServiceDbContext _db;

        public DetailsModel(BikeServiceDbContext db)
        {
            _db = db;
        }

        public ServiceHeader serviceHeader { get; set; }

        public List<ServiceDetails> serivceDetails { get; set; }


        public void OnGet(int serviceId)
        {
            serviceHeader = _db.ServiceHeaders.Include(x => x.Bike).Include(x => x.Bike.ApplicationUser).FirstOrDefault(x => x.Id == serviceId);

            serivceDetails = _db.ServiceDetails.Where(x => x.ServiceHeaderId == serviceId).ToList();
        }
    }
}
