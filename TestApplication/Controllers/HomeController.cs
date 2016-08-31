using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;

        public HomeController()
        {
            _employeeService = new EmployeeService();
        }
        public async System.Threading.Tasks.Task<ActionResult> Index(string filterTag = "")
        {
            ViewBag.Name = User.Identity.GetUserName<string>();
            
            List<Employee> employees = await _employeeService.GetAllEmployees();

            if (filterTag != "")
            {               
                return View(employees.Where(empl => empl.Tags.Exists(t => t == filterTag)));
            }
            return View(employees);
        }

        public ActionResult Info(Employee employee)
        {
            ViewBag.Name = User.Identity.GetUserName<string>();
            return View(employee);
        }
    }
}