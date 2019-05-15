namespace GAPWEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Complaint
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Category_Of_Crime { get; set; }

        [Required]
        [StringLength(30)]
        public string Suspect_Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Details { get; set; }

        public DateTime Incident_Date_And_Time { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [StringLength(100)]
        public string Information_Source { get; set; }

        [Required]
        [StringLength(1500)]
        public string Additional_Information { get; set; }

        public int Status { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
