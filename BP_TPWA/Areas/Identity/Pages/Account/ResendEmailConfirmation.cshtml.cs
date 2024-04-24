// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using BP_TPWA.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System.Net;
using MailKit.Net.Smtp;

namespace BP_TPWA.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<Uzivatel> _userManager;
        private readonly IEmailSender _emailSender;

        public ResendEmailConfirmationModel(UserManager<Uzivatel> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [StringLength(100, ErrorMessage = "{0} musí být alespoň {2} znaků dlouhé a maximálně {1} znaků dlouhé.", MinimumLength = 5)]
            [EmailAddress(ErrorMessage = "Zadejte platnou emailovou adresu.")]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Ověřovací email poslán. Zkontroluj email..");
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await SendEmailAsync(
                Input.Email,
                "Potvrď svůj email",
                $"Potvrď prosím svůj email <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kliknutím zde</a>.");

            ModelState.AddModelError(string.Empty, "Ověřovací email poslán. Zkontroluj email.");
            return Page();
        }
        private async Task<bool> SendEmailAsync(string email, string subject, string confirmLink)
        {
            try
            {
                var emailS = new MimeMessage();
                emailS.From.Add(MailboxAddress.Parse("traininplanWebapp@seznam.cz"));
                emailS.To.Add(MailboxAddress.Parse(email));
                emailS.Subject = subject;
                emailS.Body = new TextPart(TextFormat.Html) { Text = confirmLink };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("tom.douglas@ethereal.email", "kBbGB776mcZgmu2hwY");
                    smtp.Send(emailS);
                    smtp.Disconnect(true);
                }

                //MailMessage message = new MailMessage();
                //SmtpClient smtpClient = new SmtpClient();
                //message.From = new MailAddress("traininplanwebapp@gmail.com");
                //message.To.Add("kidik.mlcousek@gmail.com");
                //message.Subject = subject;
                //message.IsBodyHtml = true;
                //message.Body = confirmLink;

                //smtpClient.Port = 25;
                //smtpClient.Host = "smtp-relay.gmail.com";

                //smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new NetworkCredential("traininplanwebapp@gmail.com", "BPTP123*");
                //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
