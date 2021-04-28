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

    }
}
