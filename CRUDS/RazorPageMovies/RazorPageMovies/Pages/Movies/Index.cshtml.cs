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
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovies.Data.RazorPageMoviesContext _context;

        public IndexModel(RazorPageMovies.Data.RazorPageMoviesContext context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pelicula = await _context.Pelicula.ToListAsync();
        }
    }
}
