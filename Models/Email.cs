using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace alongiYardscapes.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail.")]
        [EmailAddress(ErrorMessage = "The E-Mail address you entered was not valid.")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }

        public bool emailSent { get; set; }
    }
}
