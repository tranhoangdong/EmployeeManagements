using EmployeeManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()

        {
            CompanyDBContext db = new CompanyDBContext();
            List<Employee> Employees = db.Employees.ToList();
            return View(Employees);
        }
        //[HttpPost]
        //public int SaveData(string firstname, string lastname, string address)
        //{
        //    EmployeeList EmpList = new EmployeeList();
        //    EmpList.AddEmp(firstname, lastname, address);
        //    int c = 0;
        //    return 0;
        //}
        //public ActionResult Create()
        //{
        //    return View();
        //}
    }

    
}