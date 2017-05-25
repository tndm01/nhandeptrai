using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BotDetect.Web.Mvc;
using NNShop.Common;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.Infrastructure.Extensions;
using NNShop.Web.Models;

namespace NNShop.Web.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;
        IFeedbackService _feedbackService;
        public ContactController(IContactService contactService , IFeedbackService feedbackService)
        {
            this._contactService = contactService;
            this._feedbackService = feedbackService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không đúng")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback();
                feedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(feedback);
                _feedbackService.Save();
                ViewData["SuccessMsg"] = "Gửi phản hồi thành công!";

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                feedbackViewModel.Name = "";
                feedbackViewModel.Message = "";
                feedbackViewModel.Email = "";
            }
            feedbackViewModel.ContactDetail = GetDetail();         
            return View("Index", feedbackViewModel);
        }

        private ContactViewModel GetDetail()
        {
            var model = _contactService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactViewModel>(model);
            return contactViewModel;
        }
    }
}