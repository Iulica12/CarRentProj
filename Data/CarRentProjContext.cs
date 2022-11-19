using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Models;

namespace CarRentProj.Data
{
    public class CarRentProjContext : DbContext
    {
        public CarRentProjContext (DbContextOptions<CarRentProjContext> options)
            : base(options)
        {
        }

        public DbSet<CarRentProj.Models.Car> Car { get; set; } = default!;
        public DbSet<CarRentProj.Models.Make> Make { get; set; } = default!;
    }
}
