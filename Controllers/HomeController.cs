using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMovieRepository _repository;    //add private repository variable that can be updated

        private MovieDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, IMovieRepository repo, MovieDbContext con)
        {
            _logger = logger;
            _repository = repo;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(Movies newMovie)
        {
            if (ModelState.IsValid)                 //if the model is valid (required fields not null) display the confirmation page
            {
                context.Movies.Add(newMovie);       //add movie to the db context and save changes
                context.SaveChanges();
                return View("Confirmation", newMovie);
            }
            else
            {
                return View();                      //if model is unvalid, stay on the page with the displayed error messages
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            return View(_repository.Movies.Where(Movies => Movies.Title != "Independence Day"));   //display list of movies, excluding Independence Day
        }

        [HttpPost]
        public IActionResult MovieList(Movies mov)
        {
            context.Movies.Remove(mov);     //remove movie from db context and save changes
            context.SaveChanges();
            return View(_repository.Movies);
        }

        [HttpGet]
        public IActionResult EditMovie(Movies mov)  
        {
            return View(_repository.Movies.Where(m => m.MovieId == mov.MovieId));   //display selected movie to edit on EditMovie page
        }

        [HttpPost]
        public IActionResult EditMovie(Movies mov, string category, string title, int year, string director, string rating, bool edited, string lentTo, string notes)
        {
            var entity = context.Movies.FirstOrDefault(m => m.MovieId == mov.MovieId);  //create entity object from the context with the selected movie id
            if (entity != null)
            {                                       //update the movie with any changes
                entity.Category = category;
                entity.Title = title;
                entity.Year = year;
                entity.Director = director;
                entity.Rating = rating;
                entity.Edited = edited;
                entity.LentTo = lentTo;
                entity.Notes = notes;

            }
            context.SaveChanges();
            return View("MovieList", _repository.Movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
