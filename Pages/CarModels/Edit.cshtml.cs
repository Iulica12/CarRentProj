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

namespace CarRentProj.Pages.CarModels
{
    public class EditModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public EditModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList Make { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CarModels == null)
            {
                return NotFound();
            }

            var carmodel =  await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);
            if (carmodel == null)
            {
                return NotFound();
            }
            CarModel = carmodel;
            Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
                return Page();
            }

            _context.Attach(CarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(CarModel.Id))
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

        private bool CarModelExists(int id)
        {
          return _context.CarModels.Any(e => e.Id == id);
        }
    }
}
