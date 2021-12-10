using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EarthNear1.Models
{
    public class ShiftType
    {
        public int ShiftTypeId { get; set; }
        [Required(ErrorMessage = "Skriv venligst vagtens type")]
        public string ShiftName { get; set; }
    }
}
