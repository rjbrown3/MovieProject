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
        private MovieContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext con)
        {
            _context = con;
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
            //Debug.WriteLine("Rating: " + newMovie.Rating);


            if (ModelState.IsValid)                 //if the model is valid (required fields not null) display the confirmation page
            {
                _context.Add(newMovie);
                _context.SaveChanges();
                return View("Confirmation", newMovie);
            }
            else
            {
                return View();                      //if model is unvalid, stay on the page with the displayed error messages
            }
            
        }

        public ViewResult MovieList()
        {
            return View(_context.movies.Where(Movies => Movies.Title != "Independence Day")); //Displays all movies except for "Independence Day"
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
