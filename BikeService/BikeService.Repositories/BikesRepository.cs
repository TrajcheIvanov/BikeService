using BikeService.Models;
using BikeService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeService.Repositories
{
    public class BikesRepository : BaseRepository<Bike> , IBikesRepository
    {
        public BikesRepository(BikeServiceDbContext dbContext) : base(dbContext)
        {
        }

        public List<Bike> GetAllById(string userId)
        {
            return _dbContext.Bikes.Where(x => x.UserId == userId).ToList();
        }
    }
}
