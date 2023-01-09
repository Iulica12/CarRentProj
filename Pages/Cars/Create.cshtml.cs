﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentProj.Data;
using CarRentProj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CarRentProj.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public CreateModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }
        public SelectList Make { get; set; } = default!;
        public SelectList Models { get; set; } = default!;
        public SelectList Colours { get; set; } = default!;

        public IActionResult OnGet()
        {
            Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
            Models = new SelectList(_context.CarModels.ToList(), "Id", "Name");
            Colours = new SelectList(_context.Colours.ToList(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
                Models = new SelectList(_context.CarModels.ToList(), "Id", "Name");
                Colours = new SelectList(_context.Colours.ToList(), "Id", "Name");
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //pt dropdown
        public async Task<JsonResult> OnGetCarModels(int makeId)
        {
            var models = await _context.CarModels
                .Where(x => x.MakeId == makeId)
                .ToListAsync();
            return new JsonResult(models);
        }
    }
}
