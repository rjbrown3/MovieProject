using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movies> Movies => _context.Movies;

        public void AddMovie(Movies newMovie)
        {
            _context.Set<Movies>().Add(newMovie);
        }

    }
}
