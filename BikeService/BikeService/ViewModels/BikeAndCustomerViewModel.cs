using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels
{
    public class BikeAndCustomerViewModel
    {
        public ApplicationUserViewModel UserObj { get; set; }

        public List<BikeViewModel> Bikes { get; set; }
    }
}
