using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;
using RazorPageMovies.Models;

namespace RazorPageMovies.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageMovies.Data.RazorPageMoviesContext _context;

        public DetailsModel(RazorPageMovies.Data.RazorPageMoviesContext context)
        {
            _context = context;
        }

        public Pelicula Pelicula { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            else
            {
                Pelicula = pelicula;
            }
            return Page();
        }
    }
}
