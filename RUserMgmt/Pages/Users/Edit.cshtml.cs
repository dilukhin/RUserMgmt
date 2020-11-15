using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RUserMgmt.Data;
using RazorUserMgmt.Models;

namespace RUserMgmt.Pages.Users
{
    public class EditModel : UserRolesPageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public EditModel(RUserMgmt.Data.RUserMgmtContext context)
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

            User = await _context.Users
                .Include(i => i.UsersRoles).ThenInclude(i => i.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }
            PopulateAssignedRoleData(_context, User);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedRoles)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToUpdate = await _context.Users
                .Include(i => i.UsersRoles)
                    .ThenInclude(i => i.Role)
                .FirstOrDefaultAsync(s => s.UserId == id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                userToUpdate,
                "User",
                i => i.LoginName, i => i.FullName,
                i => i.Email, i => i.Password))
            {
                UpdateUserRoles(_context, selectedRoles, userToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateUserRoles(_context, selectedRoles, userToUpdate);
            PopulateAssignedRoleData(_context, userToUpdate);
            return Page();
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
