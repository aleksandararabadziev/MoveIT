using Microsoft.AspNetCore.Mvc;
using SmallProject.Models;
using SmallProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallProject.API.Controllers
{
    public class SharedController : Controller
    {
        #region Declarations

        private readonly ISharedService _sharedService;

        #endregion

        #region Ctor

        public SharedController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }

        #endregion

        /// <summary>
        /// Returns all app settings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAppSettings()
        {
            var settings = _sharedService.GetAppSettings();
            return Json(settings);
        }
    }
}
