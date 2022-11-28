using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;

namespace CarRentProj.Pages.Rents
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public DetailsModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

      public Rent Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FirstOrDefaultAsync(m => m.ID == id);
            if (rent == null)
            {
                return NotFound();
            }
            else 
            {
                Rent = rent;
            }
            return Page();
        }
    }
}
