using MovieGenreDemoPro.DAL;
using MovieGenreDemoPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieGenreDemoPro.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext _context;
        public MovieController()
        {
            _context = new MovieContext();
        }
        public ActionResult Index()
        {
            List<Movie> movieList = _context.movies.Include("movieGenre").ToList();
            return View(movieList);
        }
   
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> genresList = new List<SelectListItem>();
            foreach (MovieGenre mg in _context.movieGenres)
            {
                genresList.Add(new SelectListItem() { Text = mg.MovieGenreName, Value = mg.MovieGenreId.ToString() });
            }
            ViewBag.MovieGenreId = genresList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie m)
        {
            m.movieImagefile = Request.Files[0];
            m.ImagePath = "/Images/" + m.movieImagefile.FileName;
            if (ModelState.IsValid)
            {
                m.movieImagefile.SaveAs(Server.MapPath(m.ImagePath));
            _context.movies.Add(m);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie m = _context.movies.Find(id);
            List<SelectListItem>genresList = new List<SelectListItem>();
            foreach (MovieGenre mg in _context.movieGenres)
            {
                if (mg.MovieGenreId == m.MovieGenreId)
                {
                    genresList.Add(new SelectListItem()
                    {
                        Text = mg.MovieGenreName,
                        Value = mg.MovieGenreId.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    genresList.Add(new SelectListItem() { Text = mg.MovieGenreName, Value = mg.MovieGenreId.ToString() });
                }
            } 
                ViewBag.MovieGenreId = genresList;
                return View(m);    
        }
        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            Movie x = _context.movies.Find(m.MovieId);
            x.MovieName = m.MovieName;
            x.MovieDescription = m.MovieDescription;
            x.YearOfRelease = m.YearOfRelease;
            x.MovieGenreId = m.MovieGenreId;

            if (Request.Files.Count == 1)
            {
                m.movieImagefile=Request.Files[0];
                x.ImagePath = "/Images" + m.movieImagefile.FileName;
                m.movieImagefile.SaveAs(Server.MapPath(x.ImagePath));

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Movie m = _context.movies.Include("movieGenre").First(x => x.MovieId == id);
            return View(m);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie x = _context.movies.Find(id);
            _context.movies.Remove(x);
            _context.SaveChanges();
            //List<Movie> mlist = _context.movies.ToList();
            //return View("Index", mlist);
            return RedirectToAction("Index");
        }
    }
}
