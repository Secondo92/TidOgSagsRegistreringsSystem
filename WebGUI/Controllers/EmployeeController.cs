using BLL;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class EmployeeController : Controller
    {
        // Liste over medarbejdere
        public ActionResult Index()
        {
            var employees = EmployeeBLL.GetAllEmployees();
            return View(employees);
        }

        // Vis detaljer for en medarbejder
        public ActionResult Details(string cpr)
        {
            var employee = EmployeeBLL.GetEmployeeByCpr(cpr);
            if (employee == null)
            {
                return HttpNotFound();
            }

            // Overfør sager fra WPF (hårdkodet for nu)
            var cases = CaseBLL.GetAllCases();
            ViewBag.Cases = new SelectList(cases, "CaseNumber", "Headline");

            return View(employee);
        }

        // Registrér tid
        [HttpPost]
        public ActionResult RegisterTime(TimeRegistrationDTO timeRegistration)
        {
            if (ModelState.IsValid)
            {
                TimeRegistrationBLL.CreateTimeRegistration(timeRegistration);
                return RedirectToAction("Details", new { cpr = timeRegistration.EmployeeId });
            }

            return View("Details", timeRegistration.EmployeeId);
        }
    }
}
