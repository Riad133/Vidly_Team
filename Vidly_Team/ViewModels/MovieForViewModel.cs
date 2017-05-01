using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Team.Models;

namespace Vidly_Team.ViewModels
{
    public class MovieForViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}