using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RUserMgmt.Data;
using RazorUserMgmt.Models;
using RazorUserMgmt.Models.RUMViewModels;

namespace RUserMgmt.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public IndexModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        public UserIndexData UserData { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public async Task OnGetAsync(int? id)
        {
            UserData = new UserIndexData();
            UserData.Users = await _context.Users
                .Include(i => i.UsersRoles)
                .ThenInclude(i => i.Role)
                .OrderBy(i => i.LoginName)
                .ToListAsync()
                ;
            if (id != null)
            {
                UserID = id.Value;
                User User = UserData.Users
                    .Where(i => i.UserId == id.Value).Single();
                UserData.Roles = User.UsersRoles.Select(s => s.Role);
            }

        }
    }
}
