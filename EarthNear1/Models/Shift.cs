using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EarthNear1.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }

        [BindProperty, EnumDataType(typeof(TypeOfShift))]
        public string ShiftType { get; set; }

        public TypeOfShift TypeOfShift { get; set; }

        public string ShiftStatus { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{dd/MM/yyyy}"), DataType(DataType.Date)]
        public DateTime Date { get; set; }

        
        public TimeSpan TimeFrom { get; set; }
        
        
        public TimeSpan TimeTo { get; set; }

    }
}
