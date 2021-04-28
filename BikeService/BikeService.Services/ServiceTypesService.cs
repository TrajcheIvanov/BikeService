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
    }
}
