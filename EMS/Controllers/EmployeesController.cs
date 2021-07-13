using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;
using EMS.Models.ViewModels;

namespace EMS.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        DbModelEmployee db = new DbModelEmployee();
        // GET: Employees
        
        public ActionResult Index()
        {
            
            return View(db.tblEmployees.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Postion = new SelectList(db.tblPositions, "positionId", "Position");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                if (evm.Picture != null)
                {
                    string filepath = Path.Combine("~/EmployeeImages", Guid.NewGuid().ToString() + Path.GetExtension(evm.Picture.FileName));
                    evm.Picture.SaveAs(Server.MapPath(filepath));

                    tblEmployee employee = new tblEmployee
                    {
                        Title = evm.Title,
                        eName = evm.eName,
                        DateOfBirth = evm.DateOfBirth,
                        eGender = evm.eGender,
                        PhoneNo = evm.PhoneNo,
                        positionId = evm.positionId,
                        eImage = filepath
                    };
                    db.tblEmployees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Postion = new SelectList(db.tblPositions, "positionId", "Position");
            return View(evm);
        }
        public ActionResult Delete(int? id)
        {
            
            tblEmployee employees = db.tblEmployees.Find(id);

            string file_name = employees.eImage;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)//check file exsit or not  
            {
                file.Delete();
            }
            var del = (from tblEmployee in db.tblEmployees where tblEmployee.eId == id select tblEmployee).FirstOrDefault();
            db.tblEmployees.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmployee employ = db.tblEmployees.Find(id);
            if (employ == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel evm = new EmployeeViewModel
            {
                eId = employ.eId,
                Title = employ.Title,
                eName = employ.eName,
                DateOfBirth = employ.DateOfBirth,
                eGender = employ.eGender,
                PhoneNo = employ.PhoneNo,
                positionId = employ.positionId,
                eImage = employ.eImage

            };
            ViewBag.Postion = new SelectList(db.tblPositions, "positionId", "Position", evm.positionId);
            return View(evm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                string filepath = evm.eImage;
                if (evm.Picture != null)
                {
                    
                    string path = Server.MapPath(filepath);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not  
                    {
                        file.Delete();
                    }

                    filepath = Path.Combine("~/EmployeeImages", Guid.NewGuid().ToString() + Path.GetExtension(evm.Picture.FileName));
                    evm.Picture.SaveAs(Server.MapPath(filepath));
                    tblEmployee employee = new tblEmployee
                    {
                        eId = evm.eId,
                        Title = evm.Title,
                        eName = evm.eName,
                        DateOfBirth = evm.DateOfBirth,
                        eGender = evm.eGender,
                        PhoneNo = evm.PhoneNo,
                        positionId = evm.positionId,
                        eImage = filepath
                    };
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    tblEmployee employee = new tblEmployee
                    {
                        eId = evm.eId,
                        Title = evm.Title,
                        eName = evm.eName,
                        DateOfBirth = evm.DateOfBirth,
                        eGender = evm.eGender,
                        PhoneNo = evm.PhoneNo,
                        positionId = evm.positionId,
                        eImage = filepath
                    };
                    db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Postion = new SelectList(db.tblPositions, "positionId", "Position", evm.positionId);
            return View(evm);
        }

    }
}