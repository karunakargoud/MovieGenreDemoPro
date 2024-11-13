using MovieGenreDemoPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieGenreDemoPro.DAL
{
    public class MovieContext:DbContext
    {
        public MovieContext() : base()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");
            modelBuilder.Entity<Movie>().ToTable("Movie"); 
        }
        public DbSet<MovieGenre>movieGenres { get; set; }
        public DbSet<Movie> movies { get; set;}

    }
}