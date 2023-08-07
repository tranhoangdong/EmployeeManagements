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
        public ActionResult Index(string search="")
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            // List<Employee> Employees = db.Employees.ToList();
            List<Employee> Employees = db.Employees.Where(row => row.LastName.Contains(search)).ToList();
            ViewBag.Search = search;
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
        public ActionResult Detail(int id)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            Employee Emp = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(Emp);

        }
        public ActionResult Edit(int id)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult Edit(Employee Emp)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            Employee employee = db.Employees.Where(row => row.Id == Emp.Id).FirstOrDefault();

            //update
            employee.FirstName = Emp.FirstName;
            employee.LastName = Emp.LastName;
            employee.Address = Emp.Address;
            employee.BirthPlace = Emp.BirthPlace;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult Delete(int id,Employee p)
        {
            EmployeeManagementEntities1 db = new EmployeeManagementEntities1();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index ");

        }
    }
}