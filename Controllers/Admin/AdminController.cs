using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementSystem.Helpers;
using AssetManagementSystem.Models;
using AssetManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AssetManagementSystem.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _config;
        readonly connectionString _helper;

        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDBContext _context;

        public AdminController(IConfiguration config, ILogger<AdminController> logger, ApplicationDBContext context)
        {
            _config = config;
            _helper = new connectionString(_config);
            _context = context;
        }

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

        [HttpGet]
        public IActionResult AssetCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssetCategory(AssetCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string CategoryExistQuery = $"Select * from AssetCategoryMaster where AssetCategoryName=LTRIM(RTRIM('{model.AssetCategoryName}'))";
                bool CategoryExists = _helper.DataAlreadyExists(CategoryExistQuery);

                if (CategoryExists == true)
                {
                    ViewBag.Error = "This category name already exists.";
                    return View(model);
                }
                else
                {
                    string CatInsertQuery = $"Insert into AssetCategoryMaster(AssetCategoryName, AssetCategoryDesc, IsActive, CreatedDtTm, CreatedBy, ModifiedDtTm, ModifiedBy, Remarks) values(LTRIM(RTRIM('{model.AssetCategoryName}')),'{model.AssetCategoryDesc}',1,GETDATE(),NULL,NULL,NULL,NULL)";
                    int result = _helper.DMLTransaction(CatInsertQuery);

                    if (result > 0)
                    {
                        ViewBag.Success = "A new category has been created now.";
                        return View(model);
                    }
                }

                return View(model);
            }
            else
            {
                TempData["errormessage"] = "Empty form can't be submitted!";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AssetSubCategory()
        {
            List<AssetCategoryModel> categorylist = new List<AssetCategoryModel>();
            categorylist = (from AssetCategoryName in _context.AssetCategoryMaster
                            select AssetCategoryName).ToList();

            categorylist.Insert(0, new AssetCategoryModel { AssetCategoryId = 0, AssetCategoryName = "Select Category" });
            ViewBag.ListofCategory = categorylist;
            return View();

        }

        [HttpPost]
        public IActionResult AssetSubCategory(AssetSubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string SubCategoryExistQuery = $"Select * from AssetSubCategoryMaster where AssetSubCategoryName=LTRIM(RTRIM('{model.AssetSubCategoryName}'))";
                bool SubCategoryExists = _helper.DataAlreadyExists(SubCategoryExistQuery);

                if (SubCategoryExists == true)
                {
                    ViewBag.Error = "This sub category name already exists.";
                    List<AssetCategoryModel> categorylist = new List<AssetCategoryModel>();
                    categorylist = (from AssetCategoryName in _context.AssetCategoryMaster
                                    select AssetCategoryName).ToList();

                    categorylist.Insert(0, new AssetCategoryModel { AssetCategoryId = 0, AssetCategoryName = "Select Category" });
                    ViewBag.ListofCategory = categorylist;
                    return View();
                }
                else
                {
                    string SubCatInsertQuery = $"Insert into AssetSubCategoryMaster(AssetCategoryId,AssetSubCategoryName, AssetSubCategoryDesc, IsActive, CreatedDtTm, CreatedBy, ModifiedDtTm, ModifiedBy, Remarks) values('{model.AssetCategoryId}',LTRIM(RTRIM('{model.AssetSubCategoryName}')),'{model.AssetSubCategoryDesc}',1,GETDATE(),NULL,NULL,NULL,NULL)";
                    int result = _helper.DMLTransaction(SubCatInsertQuery);

                    if (result > 0)
                    {
                        ViewBag.Success = "A new sub category has been created now.";
                        List<AssetCategoryModel> categorylist = new List<AssetCategoryModel>();
                        categorylist = (from AssetCategoryName in _context.AssetCategoryMaster
                                        select AssetCategoryName).ToList();

                        categorylist.Insert(0, new AssetCategoryModel { AssetCategoryId = 0, AssetCategoryName = "Select Category" });
                        ViewBag.ListofCategory = categorylist;
                        return View();
                    }
                }

                return View();
            }
            else
            {
                TempData["errormessage"] = "Empty form can't be submitted!";
                List<AssetCategoryModel> categorylist = new List<AssetCategoryModel>();
                categorylist = (from AssetCategoryName in _context.AssetCategoryMaster
                                select AssetCategoryName).ToList();

                categorylist.Insert(0, new AssetCategoryModel { AssetCategoryId = 0, AssetCategoryName = "Select Category" });
                ViewBag.ListofCategory = categorylist;
                return View();
            }
        }

        public IActionResult AssetStatus()
        {
            return View();
        }
    }
}