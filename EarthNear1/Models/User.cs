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
        [Required(ErrorMessage = "Kodeord skal fyldes ud")]
        public string Password { get; set; }
    }
}
