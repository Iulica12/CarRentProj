using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentProj.Data;
using CarRentProj.Models;

namespace CarRentProj.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public CreateModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Make { get; set; } = default!;
        public IActionResult OnGet()
        {
            Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
                return Page();
            }

            _context.CarModels.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
