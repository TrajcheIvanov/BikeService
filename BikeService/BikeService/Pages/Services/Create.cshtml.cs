using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Models;
using BikeService.Repositories;
using BikeService.Services.interfaces;
using BikeService.Utility;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Pages.Services
{
    [Authorize(Roles =SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly BikeServiceDbContext _db;

        private readonly IBikesService _bikesService;
        public CreateModel(BikeServiceDbContext db, IBikesService bikesService)
        {
            _db = db;
            _bikesService = bikesService;
        }

        [BindProperty]
        public BikeServiceViewModel BikeServiceVM { get; set; }

        public IActionResult OnGet(int bikeId)
        {
            //var bikeToView = _bikesService.GetById(bikeId);

            BikeServiceVM = new BikeServiceViewModel
            {
                //Bike = bikeToView.ToViewModel(),
                Bike = _db.Bikes.Include(c => c.ApplicationUser).FirstOrDefault(c => c.Id == bikeId),
                ServiceHeader = new Models.ServiceHeader()
            };

            List<string> lstServiceTypeInShoppingCard = _db.ServiceShoppingCarts
                .Include(x => x.ServiceType)
                .Where(x => x.BikeId == bikeId)
                .Select(x => x.ServiceType.Name)
                .ToList();

            IQueryable<ServiceType> lstService = from s in _db.ServiceTypes
                                                 where !(lstServiceTypeInShoppingCard.Contains(s.Name))
                                                 select s;

            BikeServiceVM.ServiceTypesList = lstService.ToList();

            BikeServiceVM.ServiceShoppingCart = _db.ServiceShoppingCarts.Include(x => x.ServiceType).Where(x => x.BikeId == bikeId).ToList();
            BikeServiceVM.ServiceHeader.TotalPrice = 0;

            foreach (var item in BikeServiceVM.ServiceShoppingCart)
            {
                BikeServiceVM.ServiceHeader.TotalPrice += item.ServiceType.Price;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                BikeServiceVM.ServiceHeader.DateAdded = DateTime.Now;
                BikeServiceVM.ServiceShoppingCart = _db.ServiceShoppingCarts.Include(x => x.ServiceType).Where(x=> x.BikeId==BikeServiceVM.Bike.Id).ToList();
                foreach (var item in BikeServiceVM.ServiceShoppingCart)
                {
                    BikeServiceVM.ServiceHeader.TotalPrice += item.ServiceType.Price;
                }

                BikeServiceVM.ServiceHeader.BikeId = BikeServiceVM.Bike.Id;

                _db.ServiceHeaders.Add(BikeServiceVM.ServiceHeader);
                _db.SaveChanges();


                foreach (var details in BikeServiceVM.ServiceShoppingCart)
                {
                    ServiceDetails serviceDetails = new ServiceDetails
                    {
                        ServiceHeaderId = BikeServiceVM.ServiceHeader.Id,
                        ServiceName = details.ServiceType.Name,
                        ServicePrice = details.ServiceType.Price,
                        ServiceTypeId = details.ServiceTypeId
                    };

                    _db.ServiceDetails.Add(serviceDetails);
                    
                }

                _db.ServiceShoppingCarts.RemoveRange(BikeServiceVM.ServiceShoppingCart);

                _db.SaveChanges();

                return RedirectToPage("../Bikes/Index", new { userId = BikeServiceVM.Bike.UserId });
            }

            return Page();
        }



       public IActionResult OnPostAddToCart()
       {
            ServiceShoppingCart objServiceCart = new ServiceShoppingCart
            {
                BikeId = BikeServiceVM.Bike.Id,
                ServiceTypeId = BikeServiceVM.ServiceDetails.ServiceTypeId
            };

            _db.ServiceShoppingCarts.Add(objServiceCart);
            _db.SaveChanges();
            return RedirectToPage("Create", new { bikeId = BikeServiceVM.Bike.Id });

       }

        public IActionResult OnPostRemoveFromCart(int serviceTypeId)
        {
            ServiceShoppingCart objServiceCart = _db.ServiceShoppingCarts.
                FirstOrDefault(x => x.BikeId == BikeServiceVM.Bike.Id && x.ServiceTypeId == serviceTypeId);

            _db.ServiceShoppingCarts.Remove(objServiceCart);
            _db.SaveChanges();
            return RedirectToPage("Create", new { bikeId = BikeServiceVM.Bike.Id });

        }
    }
}
