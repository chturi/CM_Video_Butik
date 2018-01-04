using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM_Video_Butik.Views.Contex;
using CM_Video_Butik.Models;


namespace CM_Video_Butik.Controllers
{
    public class MovieController : Controller
    {
        MovieContext db = new MovieContext();

        // GET: Movie
        public ActionResult Index()
        {
            var movies = db.MoviesDb.ToList();

            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieModels movie)
        {
            try
            {
                // TODO: Add insert logic here

                db.MoviesDb.Add(movie);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("!MOVIEID: " + movie.MovieID);



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.MoviesDb.Where( x => x.MovieID == id).FirstOrDefault());
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int onclick, MovieModels movie)
        {
            try
            {
                // TODO: Add update logic here
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {

            return View(db.MoviesDb.Where(x => x.MovieID == id).FirstOrDefault());
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MovieModels movie)
        {
            try
            {
                // TODO: Add delete logic here

                movie = db.MoviesDb.Where(x => x.MovieID == id).FirstOrDefault();
                db.MoviesDb.Remove(movie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
