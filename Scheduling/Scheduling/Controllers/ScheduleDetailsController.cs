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
    public class ScheduleDetailsController : Controller
    {
        private SchedulingContext db = new SchedulingContext();

        // GET: ScheduleDetails
        public ActionResult Index()
        {
            var scheduleDetails = db.ScheduleDetails.Include(s => s.Department).Include(s => s.Employee).Include(s => s.Job).Include(s => s.Schedule);
            return View(scheduleDetails.ToList());
        }

        // GET: ScheduleDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Title");
            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Fullname");
            //ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title");
            ViewBag.EmployeeId = new SelectList(string.Empty, "EmployeeId", "Fullname");
            ViewBag.JobId = new SelectList(string.Empty, "JobId", "Title");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "Comment");
            return View();
        }

        // POST: ScheduleDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleDetailId,Comment,Formation,ScheduleId,DepartmentId,JobId,EmployeeId")] ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleDetails.Add(scheduleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Title", scheduleDetail.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", scheduleDetail.EmployeeId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", scheduleDetail.JobId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "Comment", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Title", scheduleDetail.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", scheduleDetail.EmployeeId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", scheduleDetail.JobId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "Comment", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleDetailId,Comment,Formation,ScheduleId,DepartmentId,JobId,EmployeeId")] ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Title", scheduleDetail.DepartmentId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", scheduleDetail.EmployeeId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", scheduleDetail.JobId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "Comment", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            db.ScheduleDetails.Remove(scheduleDetail);
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

        public JsonResult GetJob(int departmentid)
        {
            var jobs = db.Jobs.Where(j => j.DepartmentId == departmentid).OrderBy(j => j.JobId).AsEnumerable();
            return Json(jobs,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployee(int jobid)
        {
            var job = db.Jobs.Where(j => j.JobId == jobid).SingleOrDefault();
            var employees = db.Employees.Where(e => e.JobSops.Any(js => js.JobSopId == job.JobSopId)).AsEnumerable();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

    }
}
