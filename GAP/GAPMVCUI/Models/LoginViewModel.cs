using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GAPMVCUI.Models
{
    public class LoginViewModel
    {
        [Required, StringLength(10), Display(Name = "Enter your User Name")]
        public string UserName { get; set; }

        [Required, StringLength(30),DataType(DataType.Password), Display(Name = "Enter your Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}