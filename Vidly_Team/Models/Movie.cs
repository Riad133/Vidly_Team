using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Team.Models
{
    //Added Movie Model 
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date At Added")]
        public DateTime DateAdded  { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [AddedDateMustBeGreaterThenRelease]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
       
        public Genre Genre { get; set; }
         [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    



    }


}



