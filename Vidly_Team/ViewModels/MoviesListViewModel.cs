using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Team.Models;

namespace Vidly_Team.ViewModel
{
    public class MoviesListViewModel 
    {
        public IEnumerable<Movie> Movies { get; set; }

        
    }
}