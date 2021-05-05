using BikeService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BikeService.ViewComponents
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly BikeServiceDbContext _db;
        public UserNameViewComponent(BikeServiceDbContext db)
        {
            _db = db;
        }

        public IViewComponentResult Ivoke()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userFromDb = _db.Users.FirstOrDefault(x => x.Id == claims.Value);

            return View(userFromDb);
        }
    }
}
