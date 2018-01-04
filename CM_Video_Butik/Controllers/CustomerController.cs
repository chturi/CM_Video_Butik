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

        // GET: Customer
        public ActionResult Index()
        {
            var customer = db.CustomerDb.ToList();

            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            catch
            {
                return View();
            }
        }
    }
}
