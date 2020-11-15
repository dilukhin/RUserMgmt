using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RUserMgmt.Models.RUMViewModels
{
    public class AssignedRoleData
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
