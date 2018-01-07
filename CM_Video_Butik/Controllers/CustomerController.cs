using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CM_Video_Butik.Models;
using CM_Video_Butik.Views.Contex;
using System.Data.Entity;

namespace CM_Video_Butik.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext db = new CustomerContext();
        MovieContext dbMovie = new MovieContext();
        CustMovContext dbCustMov = new CustMovContext();


        // GET: Customer
        public ActionResult Index()
        {
            var customer = db.CustomerDb.ToList();

            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Rent(int customerId)
        {
            
            var Movielib = dbMovie.MoviesDb.ToList();
            
            
            ViewData["customerId"] = customerId;
            return View(Movielib);
        }

        public ActionResult RentReturn(int id)
        {
            MergeModelCustMov model = new MergeModelCustMov();

            var Customer= db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault();

            try
            {
                var CustomerMovies = dbCustMov.CustMovdb.Where(x => x.CusMovID.EndsWith(id.ToString()));
                model.CustMoviesList = CustomerMovies.ToList();
            }
            catch
            {
                model.CustMoviesList = null;

            }

            model.Customers = Customer;
           
            


            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel Customer)
        {
            try
            {
                // TODO: Add insert logic here
                db.CustomerDb.Add(Customer);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            return View(db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault());
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerModel Customer)
        {
            try
            {
                // TODO: Add delete logic here
                
                Customer = db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault();
                
                    



                db.CustomerDb.Remove(Customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Rent(int customerId, int movieId)
        {
            try
            {   


         
                //Removing a rented movie from stock.
                MovieModels RentedMovie = dbMovie.MoviesDb.Where(y => y.MovieID == movieId).FirstOrDefault();
                RentedMovie.QuantityRented++;
                dbMovie.SaveChanges();


                //Find the rented movie and customer by ID
                CustomerModel Customer = db.CustomerDb.Where(x => x.CustomerID == customerId).FirstOrDefault();
                Customer.QuantityOfMovies++;
                db.SaveChanges();

                //Adding movie to rented movelist
                CustomerMoviesModell CustMov = new CustomerMoviesModell();
                CustMov.CusMovID = RentedMovie.MovieID.ToString() +"-"+ Customer.CustomerID.ToString();
                CustMov.Title = RentedMovie.Title;
                CustMov.Genre = RentedMovie.Genre;
                CustMov.Quantity = RentedMovie.QuantityTotalStock - RentedMovie.QuantityRented;
                dbCustMov.CustMovdb.Add(CustMov);
                dbCustMov.SaveChanges();
               
                     
                


                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }



    }
}
