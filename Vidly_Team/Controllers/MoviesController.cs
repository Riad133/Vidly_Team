using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Team.Models;
using Vidly_Team.ViewModel;
using Vidly_Team.ViewModels;

namespace Vidly_Team.Controllers
{
	public class MoviesController : Controller
	{
	    private ApplicationDbContext _context;

	    //
		// GET: /Movies/
	    public MoviesController()
	    {
	        _context = new ApplicationDbContext();  
	    }
		
		public ActionResult Edit(int id)
		{
		    var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
		    if (movie == null)
		    {
		        HttpNotFound();
		    }
            var viewModel = new MovieForViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
			return View("MovieForm",viewModel);
		}

	   
		//[Route("movies/List/")]
		public ActionResult Index()
		{
		    IEnumerable<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();
		    MoviesListViewModel moviesview = new MoviesListViewModel
		    {
		      Movies   = movies
            };

            return View(moviesview);
		}
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
		[Route("movies/release/{year:regex(\\d{4}):range(1900,2100)}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ReleaseByYear(int ? year,int ?month)
		{
			return Content(string.Format("Year :{0} Month :{1}", year, month));
		}

        public ActionResult New()
        {
            var movie = new MovieForViewModel
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",movie);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieView= new MovieForViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", movieView);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _context.Movies.Single(m => m.Id == movie.Id);
                dbMovie.Name = movie.Name;
                dbMovie.DateAdded = movie.DateAdded;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.NumberInStock = movie.NumberInStock;
                dbMovie.GenreId = movie.GenreId;
            }
          
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.EntityValidationErrors);
               
            }

            return RedirectToAction("Index","Movies");
        }
	}
}