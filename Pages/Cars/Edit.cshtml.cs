﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentProj.Data;
using CarRentProj.Models;
using System.Drawing;

namespace CarRentProj.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarRentProj.Data.CarRentProjContext _context;

        public EditModel(CarRentProj.Data.CarRentProjContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }
        public SelectList Make { get; set; } = default!;
        public SelectList Models { get; set; } = default!;
        public SelectList Colours { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car =  await _context.Car.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
            Models = new SelectList(_context.CarModels.ToList(), "Id", "Name");
            Colours = new SelectList(_context.Colours.ToList(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Make = new SelectList(_context.Make.ToList(), "Id", "MakeName");
                Models = new SelectList(_context.CarModels.ToList(), "Id", "Name");
                Colours = new SelectList(_context.Colours.ToList(), "Id", "Name");
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
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

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.Id == id);
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
