using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudomat.Models.Users
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public UserRoles userRole;
        public UserRoles UserRole
        {
            get
            {
                return userRole;
            }
            set
            {
                userRole = UserRoles.Teacher;
            }
        }

        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}