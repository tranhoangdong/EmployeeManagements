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
            EmployeeList EmpList = new EmployeeList();
            List<Employee> obj = EmpList.GetEmployee(String.Empty).OrderBy(x => x.Id).ToList();
            return View(obj);
        }
    }
}