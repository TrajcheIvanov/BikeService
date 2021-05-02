using System;
using System.Collections.Generic;
using System.Text;

namespace BikeService.Models
{
    public class ServiceShoppingCart
    {
        public int Id { get; set; }
        public int BikeId { get; set; }
        public Bike Bike { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
