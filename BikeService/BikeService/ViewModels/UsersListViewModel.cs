using BikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels
{
    public class UsersListViewModel
    {
        public List<ApplicationUserViewModel> ApplicationUserList { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
