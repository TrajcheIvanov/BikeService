using BikeService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Repositories
{
    public class BikeServiceDbContext : IdentityDbContext<ApplicationUser>
    {
        public BikeServiceDbContext(DbContextOptions<BikeServiceDbContext> options) : base(options)
        {
        }

        DbSet<ServiceType> ServiceTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
