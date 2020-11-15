using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RUserMgmt.Data;
using RazorUserMgmt.Models;

namespace RUserMgmt.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public IndexModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        public IList<Role> Role { get;set; }

        public async Task OnGetAsync()
        {
            Role = await _context.Roles.ToListAsync();
        }
    }
}
