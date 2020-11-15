using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorUserMgmt.Models.RUMViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<UsersRoles> UsersRoles { get; set; }
    }
}