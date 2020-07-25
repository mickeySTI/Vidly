using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        //Foreign Key
        [Required]
        public byte GenreId { get; set; }

        
        public Genre Genre { get; set; }

        [Display(Name = "Release Date")]    
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }
        
        [Display (Name = "Number In Stock")]
        public int NumberInstock { get; set; }


    }
}