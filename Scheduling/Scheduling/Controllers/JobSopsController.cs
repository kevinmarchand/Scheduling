using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Scheduling.Models.EF;

namespace Scheduling.Controllers
{
    public class JobSopsController : Controller
    {
        private SchedulingContext db = new SchedulingContext();

        // GET: JobSops
        public ActionResult Index()
        {
            return View(db.JobSops.ToList());
        }

        // GET: JobSops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSop jobSop = db.JobSops.Find(id);
            if (jobSop == null)
            {
                return HttpNotFound();
            }
            return View(jobSop);
        }

        // GET: JobSops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobSopId,Title")] JobSop jobSop)
        {
            if (ModelState.IsValid)
            {
                db.JobSops.Add(jobSop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobSop);
        }

        // GET: JobSops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSop jobSop = db.JobSops.Find(id);
            if (jobSop == null)
            {
                return HttpNotFound();
            }
            return View(jobSop);
        }

        // POST: JobSops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobSopId,Title")] JobSop jobSop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSop);
        }

        // GET: JobSops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSop jobSop = db.JobSops.Find(id);
            if (jobSop == null)
            {
                return HttpNotFound();
            }
            return View(jobSop);
        }

        // POST: JobSops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSop jobSop = db.JobSops.Find(id);
            db.JobSops.Remove(jobSop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
