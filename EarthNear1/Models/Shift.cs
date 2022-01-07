using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EarthNear1.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int ShiftTypeId { get; set; }
        public bool ShiftStatus { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }

    }
}
