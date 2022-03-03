using Microsoft.Extensions.Options;
using SmallProject.AutoMapper;
using SmallProject.Data.Interfaces;
using SmallProject.Domain;
using SmallProject.Models;
using SmallProject.Services.Interfaces;
using SmallProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
