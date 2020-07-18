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

        //Foreign Key
        public byte GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }

        public int NumberInstock { get; set; }


    }
}