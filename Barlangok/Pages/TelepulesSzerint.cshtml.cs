using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barlangok.Data;
using Barlangok.Models;
using Microsoft.EntityFrameworkCore;

namespace Barlangok.Pages
{
    public class TelepulesSzerintModel : PageModel
    {
        private readonly Barlangok.Data.BarlangokDbContext _context;

        public TelepulesSzerintModel(Barlangok.Data.BarlangokDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int KivalasztottTelepules { get; set; }

        public IList<string> Telepules  { get; set; }
        public IList<BarlangokModel> Barlangok { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Telepules = _context.Barlangok.Select(x => x.Telepules).Distinct().OrderBy(x => x).ToList();
            if (KivalasztottTelepules == 0)
                Barlangok = await _context.Barlangok.ToListAsync();
            else
                Barlangok = _context.Barlangok.Where(x => x.Telepules == KivalasztottTelepules).ToList();
        }
    }
}
