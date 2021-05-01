using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Repositories.Interfaces
{
    public interface IBikesRepository : IBaseRepository<Bike>
    {
        List<Bike> GetAllById(string userId);
    }
}
