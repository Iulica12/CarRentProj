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
    public class IndexModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public IndexModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        public IList<Rent> Rent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rent != null)
            {
                Rent = await _context.Rent
                .Include(r => r.Car)
                .ThenInclude(r=>r.CarModel)
                .ThenInclude(r=>r.Make)
                .Include(r => r.Member).ToListAsync();
            }
        }
    }
}
