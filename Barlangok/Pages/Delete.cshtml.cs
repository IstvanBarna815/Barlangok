using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barlangok.Data;
using Barlangok.Models;

namespace Barlangok.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Barlangok.Data.BarlangokDbContext _context;

        public DeleteModel(Barlangok.Data.BarlangokDbContext context)
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

            var barlangokmodel = await _context.Barlangok.FirstOrDefaultAsync(m => m.Id == id);

            if (barlangokmodel == null)
            {
                return NotFound();
            }
            else
            {
                BarlangokModel = barlangokmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barlangokmodel = await _context.Barlangok.FindAsync(id);
            if (barlangokmodel != null)
            {
                BarlangokModel = barlangokmodel;
                _context.Barlangok.Remove(BarlangokModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
