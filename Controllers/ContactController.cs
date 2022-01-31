using alongiYardscapes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Recaptcha.Web.Mvc;
using Recaptcha.Web;

namespace alongiYardscapes.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly Config _config;

        public ContactController(ILogger<AboutController> logger, IOptions<Config> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public ActionResult Index(string thankYou)
        {
            var model = new Email();
            bool flag;
            Boolean.TryParse(thankYou, out flag);
            model.emailSent = flag;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Email email)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {

            //        RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            //        if (String.IsNullOrEmpty(recaptchaHelper.Response))
            //        {
            //            ModelState.AddModelError("CaptchaValidation", "You must check the Captcha.");
            //            return View(email);
            //        }
            //        //RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            //        //if (recaptchaResult != RecaptchaVerificationResult.Success)
            //        //{
            //        //    ModelState.AddModelError("", "Incorrect captcha answer.");
            //        //}


            //        var apiKey = _config.SendGridApiKey;

            //        //This is the easy way but has no replyTo field, had to do it the hard way
            //        //var client = new SendGridClient(apiKey);
            //        //var from = new EmailAddress("chris@christinesvideos.com", "Christine Strange"); 
            //        //var reply = new EmailAddress(collection["From"], "Web Site User");
            //        //var subject = collection["Subject"];
            //        //var to = new EmailAddress(collection["From"], "Web Site User");
            //        //var plainTextContent = collection["Message"];
            //        //var htmlContent = collection["Message"];
            //        //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //        //var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

            //        var message = HttpUtility.HtmlEncode(email.Message).Replace("\n", "<br/>").Replace("\r", "").Replace("\t", "");
            //        var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
            //        client.Timeout = -1;

            //        //This email goes to Sam
            //        var sendEmail = "sam@alongiyardscapes.com";
            //        var sendName = "Sam Alongi";
            //        //var sendEmail = "mike@michaelstrange.net";
            //        //var sendName = "Sam Alongi";
            //        var requestToSam = new RestRequest(Method.Post);
            //        requestToSam.AddHeader("Authorization", "Bearer " + apiKey);
            //        requestToSam.AddHeader("Content-Type", "application/json");
            //        var jsonBodyOrder = "{\"personalizations\":" +
            //              "[{\"to\": [{ \"email\": \"" + sendEmail + "\" ,\"name\": \"" + sendName + "\"}], " +
            //              "\"subject\": \"" + email.Subject + "\"}], " +
            //              "\"from\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\" }, " +
            //              "\"reply_to\": {\"email\": \"" + email.From + "\" , \"name\": \"" + email.Name + "\"}," +
            //              "\"content\": [{\"type\": \"text/html\",\"value\": \"" + message + "\"}]}";

            //        requestToSam.AddParameter("application/json", jsonBodyOrder, ParameterType.RequestBody);
            //        IRestResponse responseOrder = client.Execute(requestToSam);
            //        if (responseOrder.IsSuccessful)
            //        {
            //            //This email goes to customer. Didn't need reply_to here just did it same way for consistency
            //            var requestToDude = new RestRequest(Method.POST);
            //            requestToDude.AddHeader("Authorization", "Bearer " + apiKey);
            //            requestToDude.AddHeader("Content-Type", "application/json");
            //            var jsonBodyThanks = "{\"personalizations\":" +
            //                "[{\"to\": [{ \"email\": \"" + email.From + "\",\"name\": \"" + email.Name + "\"}], " +
            //                "\"subject\": \"Sam Alongi: Alongi Yardscapes - " + email.Subject + "\"}], " +
            //                "\"from\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\" }, " +
            //                "\"reply_to\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\"}," +
            //                "\"content\": [{\"type\": \"text/html\",\"value\": \"Thank you for contacting me. I'll get back to you as soon as I can.<br /> - Sam Alongi <br /><br />Your Message:<br />" + message + " \"}]}";

            //            requestToDude.AddParameter("application/json", jsonBodyThanks, ParameterType.RequestBody);
            //            IRestResponse responseThanks = client.Execute(requestToDude);
            //            if (responseThanks.IsSuccessful)
            //            {
            //                return RedirectToAction("Index", new { thankYou = true });
            //            }
            //        }
            //        return View("Error");
            //    }
            //    else
            //    {
            //        email.emailSent = false;
            //    }

            //}
            //catch (Exception ex)
            //{

            //}
         
            return View(email);
        } 
    }
}
