using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieGenreDemoPro.Models
{
    public class MovieGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieGenreId {  get; set; }

        [Required]
        public string MovieGenreName {  get; set; }
        public List<Movie>movies { get; set; }
    }
}