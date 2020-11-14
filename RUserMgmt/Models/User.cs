using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorUserMgmt.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [StringLength(150)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [StringLength(250)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
