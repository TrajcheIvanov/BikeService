using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BikeService.Models
{
    public class ServiceHeader
    {
        public int Id { get; set; }
        public double Kilometers { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public string Details { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateAdded { get; set; }

        public int BikeId { get; set; }

        public virtual Bike Bike { get; set; }
    }
}
