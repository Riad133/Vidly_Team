using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Team.Models;

namespace Vidly_Team.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}