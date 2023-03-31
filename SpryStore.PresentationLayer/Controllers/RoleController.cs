using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpryStore.EntityLayer.Concrete;
using System.Linq;

namespace SpryStore.PresentationLayer.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<AppRole> _appRole;

        public RoleController(RoleManager<AppRole> appRole)
        {
            _appRole = appRole;
        }

        public IActionResult Index()
        {
            var values = _appRole.Roles.ToList();
            return View(values);
        }
    }
}
