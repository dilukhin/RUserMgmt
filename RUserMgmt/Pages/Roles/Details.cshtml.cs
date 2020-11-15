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
    public class DetailsModel : PageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public DetailsModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Roles.FirstOrDefaultAsync(m => m.RoleId == id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
