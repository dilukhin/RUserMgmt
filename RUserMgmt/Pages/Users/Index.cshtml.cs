using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RUserMgmt.Data;
using RazorUserMgmt.Models;

namespace RUserMgmt.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public IndexModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
