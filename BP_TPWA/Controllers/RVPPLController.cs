﻿using Microsoft.AspNetCore.Mvc;

namespace BP_TPWA.Controllers
{
    public class RVPPLController : Controller
    {

        public IActionResult Push()
        {
            return View();
        }

        public IActionResult Pull()
        {
            return View();
        }

        public IActionResult Legs()
        {
            return View();
        }

    }
}