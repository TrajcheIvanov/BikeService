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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BikeService.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        
        private readonly BikeServiceDbContext _db;
        public IndexModel(BikeServiceDbContext db)
        {
            
            _db = db;
        }

        [BindProperty]
        public UsersListViewModel UsersListVM { get; set; }

        public string SuccessMessage { get; set; }
        public async Task<IActionResult> OnGet(string successMessage, int productPage = 1, string searchEmail = null, string searchName = null, string searchPhone = null )
        {
            SuccessMessage = successMessage;
            var userViewModels = await _db.Users.ToListAsync();

            UsersListVM = new UsersListViewModel()
            {
                ApplicationUserList = userViewModels.Select(x => x.ToViewModel()).ToList()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }

            if (searchEmail != null)
            {
                var userEmailViewModels = await _db.Users.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
                UsersListVM.ApplicationUserList = userEmailViewModels.Select(x => x.ToViewModel()).ToList();
            }
            else
            {
                if (searchName != null)
                {
                    var userNameViewModels = await _db.Users.Where(u => u.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
                    UsersListVM.ApplicationUserList = userNameViewModels.Select(x => x.ToViewModel()).ToList();
                }
                else
                {
                    if (searchPhone != null)
                    {
                        var userEmailViewModels = await _db.Users.Where(u => u.PhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToListAsync();
                        UsersListVM.ApplicationUserList = userEmailViewModels.Select(x => x.ToViewModel()).ToList();
                    }
                }
            }

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
