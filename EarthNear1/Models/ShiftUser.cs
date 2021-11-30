using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EarthNear1.Models
{
    public class ShiftUser
    {
        public int ShiftUserId { get; set; }
        [DisplayName("Vagten")]
        public int UserId { get; set; }
        public int ShiftId { get; set; }
        [DisplayName("Jobtype")]
        public int ShiftTypeId { get; set; }
    }
}
