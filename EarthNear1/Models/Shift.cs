using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        [Required(ErrorMessage = "Udfyld venligst boksen")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Indsæt venligst en dato")]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "Indsæt venligst en dato")]
        public DateTime DateTo { get; set; }
    }
}
