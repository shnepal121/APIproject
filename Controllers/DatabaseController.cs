using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIproject.Models;
using APIproject.DataAccess; 

namespace APIproject.Controllers
{
    public class DatabaseController : Controller
    {

        public ApplicationDbContext dbContext;

        public DatabaseController(ApplicationDbContext context)
        {
            dbContext = context;
        }


        // GET: Database
        public ActionResult Index()
        {
            return View();
        }

        // GET: Database/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Database/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Database/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Database/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Database/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Database/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Database/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}