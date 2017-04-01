using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Team.Models;

namespace Vidly_Team.Controllers
{
    public class MoviesController : Controller
    {
<<<<<<< HEAD
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie(){Name = "Shrink"};
        
            return View(movie);
        }
    }
=======
        //
        // GET: /Movies/
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Terminator" };
            return View(movie);
        }
	}
>>>>>>> 737ef40b0ade6b4bbd7a830145bf079af011813e
}