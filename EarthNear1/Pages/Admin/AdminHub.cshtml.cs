using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EarthNear1.Pages.Admin
{
    public class AdminHubModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostCreateUser()
        {
            return RedirectToPage("/Users/Create");
        }
        public IActionResult OnPostCreateShift()
        {
            return RedirectToPage("/Shifts/CreateShift");
        }
        public IActionResult OnPostAllUsers()
        {
            return RedirectToPage("/Users/GetAllUsers");
        }
        public ActionResult OnPostAllShifts()
        {
            return RedirectToPage("/Shifts/GetAllShifts");
        }
        public ActionResult OnPostAllShiftUsers()
        {
            return RedirectToPage("/Types/ShiftUsers/GetAllShiftUsers");
        }
        public ActionResult OnPostCreateShiftUsers()
        {
            return RedirectToPage("/Types/ShiftUsers/CreateShiftUsers");
        }
        public ActionResult OnPostAssignBooking()
        {
            return RedirectToPage("/Book/AssignBooking");
        }
        public ActionResult OnPostAllShiftTypes()
        {
            return RedirectToPage("/Types/ShiftTypes/GetAllShiftTypes");
        }
    }
}
