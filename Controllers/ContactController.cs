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
            try
            {
                if (ModelState.IsValid)
                {

                    var apiKey = _config.SendGridApiKey;

                    //This is the easy way but has no replyTo field, had to do it the hard way
                    //var client = new SendGridClient(apiKey);
                    //var from = new EmailAddress("chris@christinesvideos.com", "Christine Strange"); 
                    //var reply = new EmailAddress(collection["From"], "Web Site User");
                    //var subject = collection["Subject"];
                    //var to = new EmailAddress(collection["From"], "Web Site User");
                    //var plainTextContent = collection["Message"];
                    //var htmlContent = collection["Message"];
                    //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    //var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                    var message = HttpUtility.HtmlEncode(email.Message).Replace("\n", "<br/>").Replace("\r", "").Replace("\t", "");
                    var client = new RestClient("https://api.sendgrid.com/v3/mail/send");
                    client.Timeout = -1;

                    //This email goes to Sandy
                    var sendEmail = "sandy@sandyplumb.com";
                    var sendName = "Sandy Plumb";
                    var requestToSandy = new RestRequest(Method.POST);
                    requestToSandy.AddHeader("Authorization", "Bearer " + apiKey);
                    requestToSandy.AddHeader("Content-Type", "application/json");
                    var jsonBodyOrder = "{\"personalizations\":" +
                          "[{\"to\": [{ \"email\": \"" + sendEmail + "\" ,\"name\": \"" + sendName + "\"}], " +
                          "\"subject\": \"" + email.Subject + "\"}], " +
                          "\"from\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\" }, " +
                          "\"reply_to\": {\"email\": \"" + email.From + "\" , \"name\": \"" + email.Name + "\"}," +
                          "\"content\": [{\"type\": \"text/html\",\"value\": \"" + message + "\"}]}";

                    requestToSandy.AddParameter("application/json", jsonBodyOrder, ParameterType.RequestBody);
                    IRestResponse responseOrder = client.Execute(requestToSandy);
                    if (responseOrder.IsSuccessful)
                    {
                        //This email goes to customer. Didn't need reply_to here just did it same way for consistency
                        var requestToDude = new RestRequest(Method.POST);
                        requestToDude.AddHeader("Authorization", "Bearer " + apiKey);
                        requestToDude.AddHeader("Content-Type", "application/json");
                        var jsonBodyThanks = "{\"personalizations\":" +
                            "[{\"to\": [{ \"email\": \"" + email.From + "\",\"name\": \"" + email.Name + "\"}], " +
                            "\"subject\": \"Sandy Plumb: Voicing Your Vision - " + email.Subject + "\"}], " +
                            "\"from\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\" }, " +
                            "\"reply_to\": {\"email\": \"" + sendEmail + "\",  \"name\": \"" + sendName + "\"}," +
                            "\"content\": [{\"type\": \"text/html\",\"value\": \"Thank you for contacting me. I'll get back to you as soon as I can.<br /> - Sandy Plumb <br /><br />Your Message:<br />" + message + " \"}]}";

                        requestToDude.AddParameter("application/json", jsonBodyThanks, ParameterType.RequestBody);
                        IRestResponse responseThanks = client.Execute(requestToDude);
                        if (responseThanks.IsSuccessful)
                        {
                            return RedirectToAction("Index", new { thankYou = true });
                        }
                    }
                    return View("Error");
                }

            }
            catch (Exception ex)
            {

            }
         
            return View();
        } 
    }
}
