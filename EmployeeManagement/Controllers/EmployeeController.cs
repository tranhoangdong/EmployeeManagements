using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            // list<employee> employees = db.employees.tolist();
            List<a.Employee> employees = db.Employees.Where(row => row.LastName.Contains(search)).ToList();
            ViewBag.search = search;
            return View(employees);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(a.Employee c)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            db.Employees.Add(c);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult detail(int id)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee emp = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(emp);

        }
        public ActionResult Edit(int id)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult Edit(a.Employee emp)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee employee = db.Employees.Where(row => row.Id == emp.Id).FirstOrDefault();

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
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            return View(employee);

        }
        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee employee = db.Employees.Where(row => row.Id == id).FirstOrDefault();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
      
        public ActionResult Index1()
        {
            return View();
        }
        
        [HttpPost]
        public int SaveData(string FirstName, string LastName, string Address, string BirthPlace)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            a.Employee employee = new a.Employee
            {
                Address = Address,
                BirthPlace = BirthPlace,
                FirstName = FirstName,
                LastName = LastName
            };
            db.Employees.Add(employee);
            db.SaveChanges();
            int c = 0;
            return 0;
        }
    }
}