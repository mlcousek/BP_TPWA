// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using BP_TPWA.Models;
using System.Globalization;
using BP_TPWA.Controllers;
//using System.Net.Mail;
using System.Net;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace BP_TPWA.Areas.Identity.Pages.Account
{
    public class WeightRangeAttribute : ValidationAttribute
    {
        private readonly double _min;
        private readonly double _max;

        public WeightRangeAttribute(double min, double max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Hodnota je povinná.");
            }

            double number;

            if (double.TryParse(value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                if (number >= _min && number <= _max)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Zadejte platnou váhu.");
                }
            }
            else
            {
                return new ValidationResult("Prosím, zadejte platné číslo.");
            }
        }
    }


    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Uzivatel> _signInManager;
        private readonly UserManager<Uzivatel> _userManager;
        private readonly IUserStore<Uzivatel> _userStore;
        private readonly IUserEmailStore<Uzivatel> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;


        public RegisterModel(
            UserManager<Uzivatel> userManager,
            IUserStore<Uzivatel> userStore,
            SignInManager<Uzivatel> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

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
            [EmailAddress(ErrorMessage = "Zadejte prosím platnou emailovou adresu.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [StringLength(100, ErrorMessage = "{0} musí být alespoň {2} znaků dlouhé a maximálně {1} znaků dlouhé.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Heslo")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Potvrď heslod")]
            [Compare("Password", ErrorMessage = "Hesla se liší.")]
            public string ConfirmPassword { get; set; }

            [StringLength(100, ErrorMessage = "{0} musí být alespoň {2} znaků dlouhé a maximálně {1} znaků dlouhé.", MinimumLength = 1)]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Jméno")]
            public string Jméno { get; set; }
            [StringLength(100, ErrorMessage = "{0} musí být alespoň {2} znaků dlouhé a maximálně {1} znaků dlouhé.", MinimumLength = 1)]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Příjmení")]
            public string Příjmení { get; set; }
            [Range(6, 110, ErrorMessage = "Zadejte platný věk.")]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Věk")]
            public int Věk { get; set; }
            [Range(100, 300, ErrorMessage = "Zadejte platnou výšku.")]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Výška")]
            public int Výška { get; set; }
            [RegularExpression(@"^\d+([.]\d+)?$", ErrorMessage = "Zadejte platnou váhu.")]
            [WeightRange(30, 300)]
            [StringLength(5, ErrorMessage = "Zadejte platnou váhu.")]
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Váha")]
            public string Váha { get; set; }
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Pohlaví")]
            public int Pohlaví { get; set; }
            [Required(ErrorMessage = "Toto pole je povinné.")]
            [Display(Name = "Úroveň")]
            public int Úroveň { get; set; }
            public bool PridaneData { get; set; }

        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            //if (ModelState.ContainsKey("Input.Váha"))
            //{
            //    ModelState.Remove("Input.Váha");
            //}
            if (ModelState.IsValid)
            {
                double number;

                if (double.TryParse(Input.Váha, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
                {
                    // Převod byl úspěšný, number obsahuje hodnotu
                    

                    var user = CreateUser();
                    if(user != null)
                    {
                        user.Jmeno = Input.Jméno;
                        user.Prijmeni = Input.Příjmení;
                        user.Vaha = number;
                        user.Vyska = Input.Výška;
                        user.Vek = Input.Věk;
                        user.Uroven = Input.Úroveň;
                        user.Pohlavi = Input.Pohlaví;
                        user.PridaneData = false;
                        user.PomocneDatum = DateTime.Today;
                    }

                    await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                    await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {

                        _logger.LogInformation("Uživatel vytvořen s heslem.");

                        

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await SendEmailAsync(Input.Email, "Potvrď svůj email TPWA",
                            $"Prosím potvrď si účet <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kliknutím zde</a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                // Převod selhal
            }

            

            // If we got this far, something failed, redisplay form
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

        private Uzivatel CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Uzivatel>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Uzivatel)}'. " +
                    $"Ensure that '{nameof(Uzivatel)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Uzivatel> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Uzivatel>)_userStore;
        }
    }
}
