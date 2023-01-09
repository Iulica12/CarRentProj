using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentProj.Data;
using CarRentProj.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentProj.Pages.Rents
{
    public class CreateModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public CreateModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var carList = _context.Car
                .Include(b => b.Make)
                .Include(b => b.CarModel)
                .Include(b => b.Colour)
                .Select(x => new
                {
                    x.Id,
                    CarFull = x.Make.MakeName + " " + x.CarModel.Name + " " + x.Colour.Name + " " + x.LicensePlateNumber
                });
            ViewData["CarID"] = new SelectList(carList, "Id", "CarFull");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Rent Rent { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rent.Add(Rent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
