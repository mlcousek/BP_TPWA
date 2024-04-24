// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using BP_TPWA.Models;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace BP_TPWA.Areas.Identity.Pages.Account.Manage
{
    public class EmailModel : PageModel
    {
        private readonly UserManager<Uzivatel> _userManager;
        private readonly SignInManager<Uzivatel> _signInManager;
        private readonly IEmailSender _emailSender;

        public EmailModel(
            UserManager<Uzivatel> userManager,
            SignInManager<Uzivatel> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
            [StringLength(100, ErrorMessage = "{0} musí být alespoň {2} znaků dlouhé a maximálně {1} znaků dlouhé.", MinimumLength = 5)]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [EmailAddress(ErrorMessage = "Zadejte platnou emailovou adresu.")]
            [Display(Name = "Nový email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(Uzivatel user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nelze načíst uživatele s ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nelze načíst uživatele s ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = Input.NewEmail, code = code },
                    protocol: Request.Scheme);
                await SendEmailAsync(
                    Input.NewEmail,
                    "Potvrď svůj email",
                    $"Prosím potvrď svůj účet <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kliknutím zde</a>.");

                StatusMessage = "Potvrzovací odkaz pro změnu email poslán. Zkontroluj email.";
                return RedirectToPage();
            }

            StatusMessage = "Tvůj email se nezměnil.";
            return RedirectToPage();
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

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nelze načíst uživatele s ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Potvrď svůj email",
                $"Prosím potvrď svůj účet <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kliknutím zde</a>.");

            StatusMessage = "Potvrzovací email poslán. Zkontroluj email..";
            return RedirectToPage();
        }
    }
}
