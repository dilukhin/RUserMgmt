using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RUserMgmt.Data;
using RazorUserMgmt.Models;

namespace RUserMgmt.Pages.Users
{
    public class CreateModel : UserRolesPageModel
    {
        private readonly RUserMgmt.Data.RUserMgmtContext _context;

        public CreateModel(RUserMgmt.Data.RUserMgmtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new User();
            instructor.UsersRoles = new List<UsersRoles>();

            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedRoleDataList)
            // in the Create Razor page.
            PopulateAssignedRoleData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedRoles)
        {
            var newUser = new User();
            if (selectedRoles != null)
            {
                newUser.UsersRoles = new List<UsersRoles>();
                foreach (var course in selectedRoles)
                {
                    var courseToAdd = new UsersRoles
                    {
                        RoleId = int.Parse(course)
                    };
                    newUser.UsersRoles.Add(courseToAdd);
                }
            }

            if (await TryUpdateModelAsync<User>(
                newUser,
                "User",
                i => i.LoginName, i => i.FullName,
                i => i.Email, i => i.Password))
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedRoleData(_context, newUser);
            return Page();
        }
    }
}
