using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;
using SpryStore.BusinessLayer.ValidationRules.ContactValidationRules;
using SpryStore.EntityLayer.Concrete;
using System;

namespace SpryStore.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            ContactAddValidator validationRules = new ContactAddValidator();
            ValidationResult result = validationRules.Validate(contact);
            if (result.IsValid)
            {
                contact.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _contactService.Insert(contact);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _contactService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            contact.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }
    }
}
