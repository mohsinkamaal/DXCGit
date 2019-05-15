using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAPMVCUI.Models
{
    public class RegisterViewModel
    {
        [Required, StringLength(30), Display(Name ="Enter First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(10), Display(Name = "Enter Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(50),DataType(DataType.EmailAddress), Display(Name = "Enter Email Address")]
        public string EmailAddress { get; set; }

        [Required, StringLength(10), Display(Name = "Enter User Name")]
        public string UserName { get; set; }

        [Required, StringLength(30),DataType(DataType.Password), Display(Name = "Enter Password")]
        public string Password { get; set; }

        [Required,StringLength(30),DataType(DataType.Password),Compare("Password"), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        
    }
}