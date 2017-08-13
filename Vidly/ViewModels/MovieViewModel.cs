using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required, Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required, Range(1, 20), Display(Name = "Number In Stock")]
        public int? AvailableAmount { get; set; }

        [Required, Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Movie" : "Edit Movie";
            }
        }

        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            AvailableAmount = movie.AvailableAmount;
            GenreId = movie.GenreId;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}