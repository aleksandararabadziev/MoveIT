using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallProject.Services.Interfaces;
namespace SmallProject.API.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        #region Declarations


        #endregion

        #region Ctor

        public TestController()
        {

        }

        #endregion

        public IActionResult VerifyConnection()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Ping()
        {
            return Json("Ping successfull");
        }
    }
}
