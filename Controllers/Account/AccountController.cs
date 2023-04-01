using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementSystem.Helpers;
using AssetManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AssetManagementSystem.Controllers.Account
{
    public class AccountController : Controller
    {

        private readonly IConfiguration _config;
        readonly connectionString _helper;

        public AccountController(IConfiguration config)
        {
            _config = config;
            _helper = new connectionString(_config); 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UserExistQuery = $"Select * from UserMaster where Email='{model.Email}' and Password='{model.Password}'";
                bool UserExists = _helper.UserAlreadyExists(UserExistQuery);

                if (UserExists == true)
                {
                    CreateUserSession(model.Email);
                    return LocalRedirect("/Admin/AssetCategory");
                }
            }
            else
            {
                TempData["errormessage"] = "Email & Password fields be submitted!";
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignupUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                string UserExistQuery = $"Select * from UserMaster where Email='{model.Email}'";
                bool UserExists = _helper.UserAlreadyExists(UserExistQuery);

                if (UserExists == true)
                {
                    ViewBag.Error = "Username or Emailid already exists.";
                    return View(model);
                }

                string UserInsertQuery = $"Insert into UserMaster(Username, Email, Mobile, Password, IsActive, CreatedDttm, Remarks) values('{model.Username}','{model.Email}','{model.Mobile}','{model.Password}',1,GETDATE(),'Created from SignUp Form')";
                int result = _helper.DMLTransaction(UserInsertQuery);

                if (result > 0)
                {
                    CreateUserSession(model.Email);
                    ViewBag.Success = "User has been registered now.";
                    return LocalRedirect("/Asset/Asset");
                    //return View(model);
                }

                return View(model);
            }
            else
            {
                TempData["errormessage"] = "Empty form can't be submitted!";
                return View(model);
            }
        }

        private void CreateUserSession(string Email)
        {
            HttpContext.Session.SetString("Email", Email);
        }
    }
}