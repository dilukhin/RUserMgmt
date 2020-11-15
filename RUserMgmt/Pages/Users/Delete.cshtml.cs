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
    public class DeleteModel : PageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public DeleteModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _context.Users
                .Include(i => i.UsersRoles)
                .SingleAsync(i => i.UserId == id);

            if (user == null)
            {
                return RedirectToPage("./Index");
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
