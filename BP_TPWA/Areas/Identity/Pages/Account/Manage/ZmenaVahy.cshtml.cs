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
using BP_TPWA.Controllers;
using BP_TPWA.Data;
using System.Security.Claims;

namespace BP_TPWA.Areas.Identity.Pages.Account.Manage
{
    public class ZmenaVahyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ZmenaVahyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uzivatel = _context.Users
                               .Where(dt => dt.Id == userId)
                               .ToList();

            ViewData["Uzivatel"] = uzivatel;
        }
    }
}
