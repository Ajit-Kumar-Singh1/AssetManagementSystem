using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Asset()
        {
            return View();
        }

        public IActionResult AssetHistory()
        {
            return View();
        }
        public IActionResult AssetStatus()
        {
            return View();
        }
    }
}