using SmallProject.AutoMapper;
using SmallProject.Data.Interfaces;
using SmallProject.Domain;
using SmallProject.Services.Interfaces;
using SmallProject.Settings;

namespace SmallProject.Services
{
    public class SharedService : ISharedService
    {
        #region Declarations

        private readonly IRepository<DistancePrice> _distanceRepository;

        #endregion

        #region Ctor

        public SharedService(IRepository<DistancePrice> distanceRepository)
        {
            _distanceRepository = distanceRepository;
        }

        #endregion

        #region App settings

        public AppSettingsModel GetAppSettings()
        {
            var appSettings = AppSettingsLocator.Settings;

            return appSettings.ToModel<AppSettingsModel, AppSettings>();
        }

        #endregion
    }
}
