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


    }
}
