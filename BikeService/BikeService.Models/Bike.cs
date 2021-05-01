using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BikeService.Models
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string Style { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double Kilometers { get; set; }

        public string Color { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
