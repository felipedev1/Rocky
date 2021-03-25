using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationTypes = _db.ApplicationTypes;
            return View(applicationTypes);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                NotFound();
            }

            var applicationType = _db.ApplicationTypes.Find(id);
            if(applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }

            var applicationType = _db.ApplicationTypes.Find(id);
            if (applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ApplicationType applicationType)
        {
 
            if(applicationType == null)
            {
                NotFound();
            }

            _db.ApplicationTypes.Remove(applicationType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
