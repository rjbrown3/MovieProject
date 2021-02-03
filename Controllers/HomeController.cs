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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            MovieTempStorage.AddMovie(newMovie);
            if (ModelState.IsValid)                 //if the model is valid (required fields not null) display the confirmation page
            {
                return View("Confirmation", newMovie);
            }
            else
            {
                return View();                      //if model is unvalid, stay on the page with the displayed error messages
            }
            
        }

        public ViewResult MovieList()
        {
            return View(MovieTempStorage.Movies.Where(Movies => Movies.Title != "Independence Day")); //Displays all movies except for "Independence Day"
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
