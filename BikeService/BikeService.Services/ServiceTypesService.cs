using BikeService.Models;
using BikeService.Repositories.Interfaces;
using BikeService.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Services
{
    public class ServiceTypesService : IServiceTypesService
    {
        private readonly IServiceTypesRepository _serviceTypesRepository;
        public ServiceTypesService(IServiceTypesRepository serviceTypesRepository)
        {
            _serviceTypesRepository = serviceTypesRepository;
        }

        public void Create(ServiceType serviceType)
        {
            _serviceTypesRepository.Add(serviceType);
        }

        public List<ServiceType> GetAll()
        {
            return _serviceTypesRepository.GetAll();
        }

        public ServiceType GetById(int id)
        {
            return _serviceTypesRepository.GetById(id);
        }

        public void Update(ServiceType serviceType)
        {
            var modelForUpdate = _serviceTypesRepository.GetById(serviceType.Id);

            if (modelForUpdate == null)
            {
                return;
            }
            else
            {
                modelForUpdate.Name = serviceType.Name;
                modelForUpdate.Price = serviceType.Price;
                _serviceTypesRepository.Update(modelForUpdate);
            }
        }
    }
}
