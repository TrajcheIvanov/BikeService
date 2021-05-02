using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Models;
using BikeService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Pages.Services
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly BikeServiceDbContext _db;

        public HistoryModel(BikeServiceDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<ServiceHeader> ServiceHeader { get; set; }

        public string UserId { get; set; }
        public void OnGet(int bikeId)
        {
            ServiceHeader = _db.ServiceHeaders
                .Include(x => x.Bike)
                .Include(x => x.Bike.ApplicationUser)
                .Where(x => x.BikeId == bikeId)
                .ToList();

            UserId = _db.Bikes.Where(x => x.Id == bikeId).ToList().FirstOrDefault().UserId;
        }
    }
}
