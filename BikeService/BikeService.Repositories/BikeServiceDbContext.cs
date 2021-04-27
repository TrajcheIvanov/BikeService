using BikeService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Repositories
{
    public class BikeServiceDbContext : IdentityDbContext
    {
        public BikeServiceDbContext(DbContextOptions<BikeServiceDbContext> options) : base(options)
        {
        }

        DbSet<ServiceType> ServiceTypes { get; set; }
    }
}
