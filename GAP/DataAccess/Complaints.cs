using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Complaints
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string Category_Of_Crime { get; set; }

        [StringLength(30), Column(TypeName = "varchar")]
        public string Suspect_Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar")]
        public string Details { get; set; }

        [Required]
        public DateTime Incident_Date_And_Time { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required, StringLength(100), Column(TypeName = "varchar")]
        public string Information_Source { get; set; }

        [Required, StringLength(1500)]
        public string Additional_Information { get; set; }

        [Required]
        public ComplaintStatus Status { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }

        public ApplicationUser User { get; set; }
    }
}
