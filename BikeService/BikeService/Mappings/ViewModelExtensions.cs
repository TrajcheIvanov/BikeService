using BikeService.Models;
using BikeService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Mappings
{
    public static class ViewModelExtensions
    {
        public static ServiceType ToDomainModel(this ServiceTypeViewModel viewModel)
        {
            return new ServiceType
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
            };
        }

        public static ApplicationUser ToDomainModel(this ApplicationUserViewModel entity)
        {
            return new ApplicationUser()
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

        public static Bike ToDomainModel(this BikeViewModel entity)
        {

            return new Bike()
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
