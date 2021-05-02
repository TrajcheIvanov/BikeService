using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeService.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }

        public int ServiceHeaderId { get; set; }
        
        public virtual ServiceHeader ServiceHeader { get; set; }

        [Display(Name = "Service")]
        public int ServiceTypeId { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public double ServicePrice { get; set; }
        public string ServiceName { get; set; }
    }
}
