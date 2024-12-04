using BLL;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DepartmentDTO department = DepartmentBLL.GetDepartmentByNumber(1);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
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
    }
}