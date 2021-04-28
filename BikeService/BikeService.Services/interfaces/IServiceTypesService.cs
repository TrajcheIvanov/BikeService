using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Services.interfaces
{
    public interface IServiceTypesService
    {
        List<ServiceType> GetAll();
        void Create(ServiceType serviceType);
    }
}
