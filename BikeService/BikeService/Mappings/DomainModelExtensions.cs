using BikeService.Models;
using BikeService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Mappings
{
    public static class DomainModelExtensions
    {
        public static ServiceTypeViewModel ToViewModel(this ServiceType entity)
        {
            return new ServiceTypeViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        public static ApplicationUserViewModel ToViewModel(this ApplicationUser entity)
        {
            return new ApplicationUserViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                City = entity.City,
                PostalCode = entity.PostalCode,
                
            };
        }

        public static BikeViewModel ToViewModel(this Bike entity)
        {

            return new BikeViewModel()
            {

                Id = entity.Id,
                VIN = entity.VIN,
                Make = entity.Make,
                Model = entity.Model,
                Style = entity.Style,
                Year = entity.Year,
                Kilometers = entity.Kilometers,
                Color = entity.Color,
                UserId = entity.UserId
            };
        }
    }
}
