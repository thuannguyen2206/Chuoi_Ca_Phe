using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Constants;
using DataTransferObjects.DTOs.Contacts;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactApiClient _contactApi;
        private readonly INotyfService _notyf;

        public ContactController(IContactApiClient contactApi, INotyfService notyf)
        {
            _contactApi = contactApi;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new ContactDto()
            {
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message
            };
            var response = await _contactApi.AddContact(dto);
            if (response != null && response.Success)
            {
                _notyf.Success(NotificationConstants.FeedbackSuccess);
            }
            else
            {
                _notyf.Error(NotificationConstants.FeedbackFailed);
            }
            return RedirectToAction(nameof(ContactController.Index));
        }

        public IActionResult About()
        {
            return View();
        }



    }
}
