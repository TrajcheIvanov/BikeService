using BikeService.Models;
using BikeService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Repositories
{
    public class ServiceTypesRepository : BaseRepository<ServiceType>, IServiceTypesRepository
    {
        
        public ServiceTypesRepository(BikeServiceDbContext dbContext) : base (dbContext)
        {
        }
    }
}
