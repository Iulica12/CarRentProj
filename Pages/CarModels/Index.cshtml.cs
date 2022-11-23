using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;
using CarRentProj.Models.ViewModels;

namespace CarRentProj.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public IndexModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModel { get;set; } = default!;


        public CarModelIndexData CarModelData { get; set; }
        public int CarModelID { get; set; }
        public int CarID { get; set; }

        public async Task OnGetAsync(int? id, int? carID)
        {
            CarModelData = new CarModelIndexData();
            CarModelData.CarModels = await _context.CarModels
                                                            .Include(i => i.Car)
                                                            .ThenInclude(i => i.Colour)
                                                            .Include(i => i.Make)
                                                            .OrderBy(i => i.Name)
                                                            .ToListAsync();
            if (id != null)
            {
                CarModelID = id.Value;
                CarModel carmodel = CarModelData.CarModels.Where(i => i.Id == id.Value).Single();
                CarModelData.Cars = carmodel.Car;
            }
            if (_context.CarModels != null)
            {
                CarModel = await _context.CarModels.ToListAsync();
            }
        }
        
    }
}
