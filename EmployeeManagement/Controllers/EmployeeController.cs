using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            List<Employee> Employees = db.Employees.ToList();
            return View(Employees);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee c)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            db.Employees.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult Edit(int Id)
        //{

        //}
    }
}