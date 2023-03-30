using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;

namespace SpryStore.PresentationLayer.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class AboutController : Controller
    {

        private readonly IEmployeeService _employeeService;

        public AboutController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.GetList();
            return View(values);
        }

        public PartialViewResult PartialAboutCover()
        {
            return PartialView();
        }

        public PartialViewResult PartialWhatWeDo()
        {
            return PartialView();
        }

        public PartialViewResult PartialAboutEmployee()
        {
            var values = _employeeService.GetList();
            return PartialView(values);
        }

        public PartialViewResult PartialServices()
        {
            return PartialView();
        }

        public PartialViewResult PartialReference()
        {
            return PartialView();
        }
    }
}
