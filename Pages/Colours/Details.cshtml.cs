using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;

namespace CarRentProj.Pages.Colours
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public DetailsModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

      public Colour Colour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours.FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }
            else 
            {
                Colour = colour;
            }
            return Page();
        }
    }
}
