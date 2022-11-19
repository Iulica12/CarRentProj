using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;

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

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car.ToListAsync();
            }
        }
    }
}
