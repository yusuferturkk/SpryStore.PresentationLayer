using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpryStore.EntityLayer.Concrete;
using SpryStore.PresentationLayer.Models;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model) 
        {
            AppRole appRole = new AppRole()
            {
                Name = model.RoleName
            };

            await _appRole.CreateAsync(appRole);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _appRole.Roles.FirstOrDefault(x => x.Id == id);
            await _appRole.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _appRole.Roles.FirstOrDefault(x => x.Id == id);

            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                RoleId = value.Id,
                Name = value.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var value = _appRole.Roles.FirstOrDefault(x => x.Id == model.RoleId);
            value.Name = model.Name;
            await _appRole.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
