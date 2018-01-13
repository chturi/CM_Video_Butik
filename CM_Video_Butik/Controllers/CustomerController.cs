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

            var Customer = db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault();

            try
            {
                var CustomerMovies = dbCustMov.CustMovdb.Where(x => x.CusMovID.EndsWith(id.ToString()));
                model.CustMoviesList = CustomerMovies.ToList();
            }
            catch (Exception e)
            {
                model.CustMoviesList = null;
                System.Diagnostics.Debug.WriteLine(e.Message);
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

            return View(db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault());
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel Customer)
        {
            try
            {
                var customerdb = db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault();

                customerdb.FirstName = Customer.FirstName;
                customerdb.LastName = Customer.LastName;
                db.SaveChanges();

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

        public ActionResult ReturnMovie(string id)
        {

            return View(dbCustMov.CustMovdb.Where(x => x.CusMovID == id).FirstOrDefault());
        }


        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerModel Customer)
        {
            try
            {
                // TODO: Add delete logic here

                //Deleting Customers
                Customer = db.CustomerDb.Where(x => x.CustomerID == id).FirstOrDefault();
                db.CustomerDb.Remove(Customer);
                db.SaveChanges();

                try
                {
                    var CustomerMovies = dbCustMov.CustMovdb.Where(x => x.CusMovID.EndsWith(id.ToString())).ToList();

                    foreach (var movie in CustomerMovies)
                    {
                        //Deleteing Movies which are stored by the customer.
                        dbCustMov.CustMovdb.Remove(movie);
                        dbCustMov.SaveChanges();

                        //Returning Movies to stock when deleting Customers.
                        var movieStock = dbMovie.MoviesDb.Where(x => x.MovieID == Int32.Parse(movie.CusMovID.Split('-')[0])).FirstOrDefault();
                        movieStock.QuantityRented--;
                        dbMovie.SaveChanges();


                    }


                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return RedirectToAction("Index");
                }

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

                //Adding movie to rented movelist, unique ID is movie id - Customer id
                CustomerMoviesModell CustMov = new CustomerMoviesModell();
                CustMov.CusMovID = RentedMovie.MovieID.ToString() + '-' + Customer.CustomerID.ToString();
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

        [HttpPost]
        public ActionResult ReturnMovie(string CusMovID,CustomerModel ReturnedCustomer)
        {

            try
            {
                
                int customerID = Int32.Parse(CusMovID.Split('-')[1]);
                int movieID = Int32.Parse(CusMovID.Split('-')[0]);

                //Removing quantity of movies rented by the costumer
                ReturnedCustomer = db.CustomerDb.Where(x => x.CustomerID == customerID).FirstOrDefault();
                ReturnedCustomer.QuantityOfMovies--;
                db.SaveChanges();


                //Removing the movie in the rented movie tabel
                var ReturnedMoviedb = dbCustMov.CustMovdb.Where(x => x.CusMovID == CusMovID).FirstOrDefault();
                dbCustMov.CustMovdb.Remove(ReturnedMoviedb);
                dbCustMov.SaveChanges();

                //Updated the stock of the movie
                var addMovieStock = dbMovie.MoviesDb.Where(x => x.MovieID == movieID).FirstOrDefault();
                addMovieStock.QuantityRented--;
                dbMovie.SaveChanges();







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


