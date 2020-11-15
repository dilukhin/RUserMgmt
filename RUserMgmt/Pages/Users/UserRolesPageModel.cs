using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorUserMgmt.Models;
using RUserMgmt.Data;
using RUserMgmt.Models.RUMViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RUserMgmt.Pages.Users
{
    public class UserRolesPageModel : PageModel
    {
        public List<AssignedRoleData> AssignedRoleDataList;

        public void PopulateAssignedRoleData(RUserMgmtContext context,
                                               User user)
        {
            var allRoles = context.Roles;
            var instructorRoles = new HashSet<int>(
                user.UsersRoles.Select(c => c.RoleId));
            AssignedRoleDataList = new List<AssignedRoleData>();
            foreach (var role in allRoles)
            {
                AssignedRoleDataList.Add(new AssignedRoleData
                {
                    RoleId = role.RoleId,
                    Name = role.Name,
                    Assigned = instructorRoles.Contains(role.RoleId)
                });
            }
        }
        public void UpdateUserRoles(RUserMgmtContext context,
            string[] selectedRoles, User userToUpdate)
        {
            if (selectedRoles == null)
            {
                userToUpdate.UsersRoles = new List<UsersRoles>();
                return;
            }

            var selectedRolesHS = new HashSet<string>(selectedRoles);
            var userRoles = new HashSet<int>
                (userToUpdate.UsersRoles.Select(c => c.Role.RoleId));
            foreach (var role in context.Roles)
            {
                if (selectedRolesHS.Contains(role.RoleId.ToString()))
                {
                    if (!userRoles.Contains(role.RoleId))
                    {
                        userToUpdate.UsersRoles.Add(
                            new UsersRoles
                            {
                                UserId = userToUpdate.UserId,
                                RoleId = role.RoleId
                            });
                    }
                }
                else
                {
                    if (userRoles.Contains(role.RoleId))
                    {
                        UsersRoles roleToRemove
                            = userToUpdate
                                .UsersRoles
                                .SingleOrDefault(i => i.RoleId == role.RoleId);
                        context.Remove(roleToRemove);
                    }
                }
            }
        }
    }
}
