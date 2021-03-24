using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public interface IMovieRepository
    {
        IQueryable<Movies> Movies { get; }
    }
}
