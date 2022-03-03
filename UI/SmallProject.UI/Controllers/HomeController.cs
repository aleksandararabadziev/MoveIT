using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmallProject.AutoMapper;
using SmallProject.Settings;

namespace SmallProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettings) { _appSettings = appSettings.Value; }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return File("~/ClientApp/index.html", "text/html");
        }

        [HttpGet]
        public AppSettingsModel GetAppSettings()
        {
            var settings = _appSettings;

            return settings.ToModel<AppSettingsModel, AppSettings>();
        }
    }
}
