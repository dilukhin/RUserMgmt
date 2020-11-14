using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorUserMgmt.Models
{
    public class UsersRoles
    {
        [Key]
        public int UsersRolesId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
