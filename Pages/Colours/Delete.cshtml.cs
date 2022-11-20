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
    public class DeleteModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public DeleteModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }
            var colour = await _context.Colours.FindAsync(id);

            if (colour != null)
            {
                Colour = colour;
                _context.Colours.Remove(Colour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
