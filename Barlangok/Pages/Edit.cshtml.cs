using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barlangok.Data;
using Barlangok.Models;

namespace Barlangok.Pages
{
    public class EditModel : PageModel
    {
        private readonly Barlangok.Data.BarlangokDbContext _context;

        public EditModel(Barlangok.Data.BarlangokDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarlangokModel BarlangokModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangokmodel =  await _context.Barlangok.FirstOrDefaultAsync(m => m.Id == id);
            if (barlangokmodel == null)
            {
                return NotFound();
            }
            BarlangokModel = barlangokmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BarlangokModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarlangokModelExists(BarlangokModel.Id))
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

        private bool BarlangokModelExists(int id)
        {
            return _context.Barlangok.Any(e => e.Id == id);
        }
    }
}
