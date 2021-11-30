using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EarthNear1.Models
{
    public enum TypeOfShift
    {
        [Display(Name = "Bagervagt")]
        Bagervagt = 1,
        [Display(Name = "Kage-bagervagt")]
        Bagerfølvagt = 2,
        [Display(Name = "Cafévagt")]
        Cafévagt = 3,
        [Display(Name ="Café-følvagt")]
        Caféfølvagt = 4
    }
}
