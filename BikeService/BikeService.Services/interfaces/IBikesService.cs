using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Services.interfaces
{
    public interface IBikesService
    {
        List<Bike> GetAll();
        void Create(Bike bike);
        Bike GetById(int id);

        void Update(Bike bike);
        void Remove(Bike bikeForDelete);
        List<Bike> GetAllById(string userId);
    }
}
