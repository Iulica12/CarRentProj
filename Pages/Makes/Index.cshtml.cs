using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;
using System.Security.Policy;
using CarRentProj.Models.ViewModels;

namespace CarRentProj.Pages.Makes
{
    public class IndexModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public IndexModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; } = default!;
        public MakeIndexData MakeData { get; set; }
        public int MakeID { get; set; }
        public int CarModelID { get; set; }
        public async Task OnGetAsync(int? id, int? carModelID)
        {
            MakeData = new MakeIndexData();
            MakeData.Makes = await _context.Make
                                   .Include(i => i.CarModels)
                                   .OrderBy(i => i.MakeName)
                                   .ToListAsync();
            if (id != null)
            {
                MakeID = id.Value;
                Make make = MakeData.Makes.Where(i => i.Id == id.Value).Single();
                MakeData.CarModels = make.CarModels;
            }
            if (_context.Make != null)
            {
                Make = await _context.Make.Include(c => c.Car).ToListAsync();
            }
        }


    }
}
