using System.Web.Mvc;
using DTO.Models;
using BLL;
using System.Collections.Generic;
using DAL.Models;
using System.Security.Cryptography;

namespace WebGUI.Controllers
{
    public class TimeRegistrationController : Controller
    {
        private readonly static List<TimeRegistrationDTO> TimeRegistrations = TimeRegistrationBLL.GetAllTimeRegistrations();

        public ActionResult Index()
        {
            var employees = EmployeeBLL.GetAllEmployees();
            return View(employees);
        }

        // GET: TimeRegistration/Create
        public ActionResult Create(string employeeId)
        {
            var employee = EmployeeBLL.GetEmployeeByCpr(employeeId);

            var model = new TimeRegistrationDTO
            {
                EmployeeId = employeeId
            };

            // til dropdown
            ViewData["Cases"] = CaseBLL.GetAllCases();


            return View(model);
        }

        // POST: TimeRegistration/Create
        [HttpPost]
        public ActionResult Create(TimeRegistrationDTO model)
        {
            if (ModelState.IsValid)
            {
                model.TimeRegistrationId = TimeRegistrations.Count + 1;

                TimeRegistrationBLL.CreateTimeRegistration(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model); 
        }

        public ActionResult WeeklySummary(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = EmployeeBLL.GetEmployeeByCpr(employeeId);

            List<TimeReportDTO> weeklyRegistrations = TimeRegistrationBLL.GetWeeklySummary(employeeId);

            return View(weeklyRegistrations);
        }
    }
}