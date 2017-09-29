using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Web.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "帐户")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        public bool BRes { get; set; }

        public string Ticket { get; set; }

    }
}