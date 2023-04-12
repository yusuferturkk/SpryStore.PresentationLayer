using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;
using SpryStore.EntityLayer.Concrete;
using System.Threading.Tasks;

namespace SpryStore.PresentationLayer.ViewComponents
{
    public class _ContactSendMessage : ViewComponent
    {

        private readonly IContactService _contactService;

        public _ContactSendMessage(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IViewComponentResult> Invoke(Contact contact)
        //{
        //    _contactService.Insert(contact);
        //    return View();
        //}
    }
}
