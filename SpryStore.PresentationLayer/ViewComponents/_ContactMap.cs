using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;

namespace SpryStore.PresentationLayer.ViewComponents
{
    public class _ContactMap : ViewComponent
    {

        private readonly IAddressService _addressService;

        public _ContactMap(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _addressService.GetList();
            return View(values);
        }
    }
}
