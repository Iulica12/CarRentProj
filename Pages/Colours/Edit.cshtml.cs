using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarRentProj.Pages.Colours
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public EditModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Colour Colour { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colours == null)
            {
                return NotFound();
            }

            var colour =  await _context.Colours.FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }
            Colour = colour;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Colour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColourExists(Colour.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ColourExists(int id)
        {
          return _context.Colours.Any(e => e.Id == id);
        }
    }
}
