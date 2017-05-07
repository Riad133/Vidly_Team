using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Vidly_Team.Models
{
    public class AddedDateMustBeGreaterThenRelease:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if (movie.DateAdded.GetHashCode()==0  ) 
            {
                return  ValidationResult.Success;
            }
            else  
      
           if  (movie.DateAdded < movie.ReleaseDate)
            {
                return  new ValidationResult("Release date must be Greater then or equel to Release date");
            }
           else
           {
               return  ValidationResult.Success;
           }
            
        }
    }
}