using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAPMVCUI.Models
{
    public class ComplaintViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(30), Display(Name = "Complaint Category")]
        public string Category_Of_Crime { get; set; }

        [StringLength(30), Display(Name = "Suspect Name")]
        public string Suspect_Name { get; set; }

        [StringLength(150), Display(Name = "Suspect Details")]
        public string Details { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Incident Date")]
        public DateTime Incident_Date_And_Time { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, StringLength(100)]
        public string Information_Source { get; set; }

        [Required, StringLength(1500)]
        public string Additional_Information { get; set; }

        public ComplaintStatus Status { get; set; }

        public string UserName { get; set; }
    }
}