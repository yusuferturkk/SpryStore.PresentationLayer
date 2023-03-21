using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;
using SpryStore.EntityLayer.Concrete;

namespace SpryStore.PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeService.Insert(employee);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id)
        {
            var value = _employeeService.GetById(id);
            _employeeService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var value = _employeeService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.Update(employee);
            return RedirectToAction("Index");
        }
    }
}
