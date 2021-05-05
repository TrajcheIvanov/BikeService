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

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<ServiceShoppingCart> ServiceShoppingCarts { get; set; }

        public DbSet<ServiceHeader> ServiceHeaders { get; set; }

        public DbSet<ServiceDetails> ServiceDetails { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
