using BikeService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels
{
    public class BikeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string VIN { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public int Year { get; set; }

        public double Kilometers { get; set; }
        [Required]
        public string Color { get; set; }

        public string UserId { get; set; }

        
    }
}
