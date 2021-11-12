using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Udfyld dit navn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Udfyld dit efternavn")]
        public string AfterName { get; set; }
        [Required(ErrorMessage = "Angiv telefonnummer")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Udfyld mailaddresse")]
        public string Email { get; set; }
        public string Password { get; set; }
        [BindProperty, Required(ErrorMessage ="{0} skal fyldes ud"), DataType(DataType.Password), 
            Display(Name="Gentag kodeord"), Compare(nameof(Password), ErrorMessage ="forkert kodeord")]
        public string Password2 { get; set; }
        [BindProperty, DataType(DataType.Password), Display(Name = "Password")]
        public string PasswordCheck { get; set; }
        [BindProperty, Required(ErrorMessage = "{0} skal fyldes ud")]
        public bool Admin { get; set; }

    }
}
