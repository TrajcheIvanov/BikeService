using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeService.Mappings;
using BikeService.Models;
using BikeService.Repositories;
using BikeService.Utility;
using BikeService.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Pages.Users
{
    public class IndexModel : PageModel
    {
        
        private readonly BikeServiceDbContext _db;
        public IndexModel(BikeServiceDbContext db)
        {
            
            _db = db;
        }

        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1)
        {
            var userViewModels = await _db.Users.ToListAsync();

            UsersListVM = new UsersListViewModel()
            {
                ApplicationUserList = userViewModels.Select(x => x.ToViewModel()).ToList()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");

            var count = UsersListVM.ApplicationUserList.Count;

            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UsersListVM.ApplicationUserList = UsersListVM.ApplicationUserList.OrderBy(p => p.Email)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}
