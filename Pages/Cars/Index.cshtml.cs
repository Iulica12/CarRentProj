using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;
using CarRentProj.Migrations;
using CarRentProj.Models.ViewModels;

namespace CarRentProj.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public IndexModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }
        public CarModelIndexData CarD { get; set; }
        public string YearSort { get; set; }
        public string MakeSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CarD = new CarModelIndexData();
            MakeSort = String.IsNullOrEmpty(sortOrder) ? "Make_asc" : "";
            YearSort = String.IsNullOrEmpty(sortOrder) ? "Year_desc" : "";

            CurrentFilter = searchString;

            CarD.Cars = await _context.Car
                .Include(b => b.CarModel)
                .Include(b => b.Make)
                .Include(b => b.Colour)
                .AsNoTracking()
                .OrderBy(b => b.Year)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                CarD.Cars = CarD.Cars.Where(s => s.LicensePlateNumber.Contains(searchString));
            }

            if (_context.Car != null)
            {
               // Car = await _context.Cars.Include(b=>b.Make).Include(m => m.CarModel).Include(c => c.Colour).FirstOrDefaultAsync(m=>m.Id == id);
            }
            switch (sortOrder)
            {
                case "Make_asc":
                    CarD.Cars = CarD.Cars.OrderBy(s=>s.Make.MakeName);
                    break;
                case "Year_desc":
                    CarD.Cars = CarD.Cars.OrderByDescending(s => s.Year);
                    break;
            }
        }
    }
}
