using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class ApplicationUser
    {
        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [Required, StringLength(10), Column(TypeName = "varchar")]
        public string LastName { get; set; }

        [Required, StringLength(50), Column(TypeName = "varchar"), Index(IsUnique = true)]
        public string EmailAddress { get; set; }

        [Key, StringLength(10), Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string Password { get; set; }

        [Required]
        public ApplicationUserType UserType { get; set; }
    }
}
