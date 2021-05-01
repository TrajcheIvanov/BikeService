using BikeService.Models;
using BikeService.Repositories.Interfaces;
using BikeService.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Services
{
    public class BikesService : IBikesService
    {
        private readonly IBikesRepository _bikesRepository;
        public BikesService(IBikesRepository bikesRepository)
        {
            _bikesRepository = bikesRepository;
        }
        public void Create(Bike bike)
        {
            _bikesRepository.Add(bike);
        }

        public List<Bike> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Bike> GetAllById(string userId)
        {
            return _bikesRepository.GetAllById(userId);
        }

        public Bike GetById(int id)
        {
            return _bikesRepository.GetById(id);
        }

        public void Remove(Bike bikeForDelete)
        {
            _bikesRepository.Delete(bikeForDelete);
        }

        public void Update(Bike bike)
        {
            _bikesRepository.Update(bike);
        }
    }
}
