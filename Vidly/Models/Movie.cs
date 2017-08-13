using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        [Required, Range(1, 20),Display(Name = "Number In Stock")]
        public int AvailableAmount { get; set; }

        public Genre Genre { get; set; }

        [Required, Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}