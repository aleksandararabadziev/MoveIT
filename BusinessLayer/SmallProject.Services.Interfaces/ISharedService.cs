using SmallProject.Models;
using SmallProject.Settings;
using System.Collections.Generic;

namespace SmallProject.Services.Interfaces
{
    public interface ISharedService
    {
        AppSettingsModel GetAppSettings();
    }
}
