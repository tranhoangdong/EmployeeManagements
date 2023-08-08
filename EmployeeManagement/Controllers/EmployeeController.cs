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
       
        public ActionResult Index(string search = "")
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            // list<employee> employees = db.employees.tolist();
            List<Employee> employees = db.Employees.Where(row => row.LastName.Contains(search)).ToList();
            ViewBag.search = search;
            return View(employees);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee c)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            db.Employees.Add(c);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult detail(int id)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            Employee emp = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(emp);

        }
        public ActionResult Edit(int id)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            Employee employee = db.Employees.Where(row => row.Id == emp.Id).FirstOrDefault();

            //update
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.Address = emp.Address;
            employee.BirthPlace = emp.BirthPlace;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult Delete(int id, Employee p)
        {
            EmployeeManagementEntities2 db = new EmployeeManagementEntities2();
            Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index ");

        }
      
    }
}