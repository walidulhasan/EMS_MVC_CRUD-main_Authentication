using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    [Authorize]
    public class PositionsController : Controller
    {
        private DbModelEmployee db = new DbModelEmployee();

        // GET: Positions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Position()
        {
            return View(db.tblPositions.ToList());
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "positionId,Position")] tblPosition tblPosition)
        {
            if (ModelState.IsValid)
            {
                db.tblPositions.Add(tblPosition);
                db.SaveChanges();
                Response.AddHeader("Refresh","0.010");
            }

            return View(tblPosition);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPosition tblPosition = db.tblPositions.Find(id);
            if (tblPosition == null)
            {
                return HttpNotFound();
            }
            return View(tblPosition);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "positionId,Position")] tblPosition tblPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(tblPosition);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPosition tblPosition = db.tblPositions.Find(id);
            if (tblPosition == null)
            {
                return HttpNotFound();
            }
            return View(tblPosition);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tblPosition tblPosition = db.tblPositions.Find(id);
        //    db.tblPositions.Remove(tblPosition);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            try
            {
                using (DbModelEmployee db = new DbModelEmployee())
                {
                    tblPosition emp = db.tblPositions.Where(x => x.positionId == id).FirstOrDefault<tblPosition>();
                    db.tblPositions.Remove(emp);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
                //return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
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
