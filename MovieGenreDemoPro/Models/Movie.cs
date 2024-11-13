using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieGenreDemoPro.Models
{
    public class Movie
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [MaxLength(80)]
        [Required]
        public string MovieName { get; set; }

        [MaxLength(500)]
        [Required]
        public string MovieDescription { get; set; }

        [Range(1900, 2100)]
        [Required]
        public int YearOfRelease { get; set; }

        [MaxLength(80)]
        public string ImagePath { get; set; }
        [Required]
        public int MovieGenreId { get; set; }

        [NotMapped]
        public HttpPostedFileBase movieImagefile { get; set; }
        public MovieGenre movieGenre { get; set; }

    }
}