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
        [Display(Name = "Kagebagervagt")]
        Kagebagervagt = 2,
        [Display(Name = "Bagefølvagt")]
        Bagerfølvagt = 3,
        [Display(Name = "Cafévagt")]
        Cafévagt = 4,
        [Display(Name = "Caféfølvagt")]
        Caféfølvagt = 5,
        [Display(Name = "Ønsker ikke tidlig vagt")]
        ØnskerIkkeTidligVagt = 6
    }
}
