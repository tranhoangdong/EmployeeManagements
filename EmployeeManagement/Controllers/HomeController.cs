using EmployeeManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public int SaveData1(string TaiKhoan, string MatKhau)
        {
            EmployeeManagementEntities3 db = new EmployeeManagementEntities3();
            User u = new User
            {

                TaiKhoan = TaiKhoan,
                MatKhau = MatKhau
            };
            db.Users.Add(u);
            db.SaveChanges();
            int c = 0;
            return 0;
        }

    }
}