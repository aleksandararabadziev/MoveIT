using SmallProject.AutoMapper;
using SmallProject.Data.Interfaces;
using SmallProject.Domain;
using SmallProject.Models;
using SmallProject.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmallProject.Services
{
    public class PriceService : IPriceService
    {
        #region Declarations

        private readonly IRepository<DistancePrice> _distancePriceRepository;
        private readonly IRepository<VolumePrice> _volumePriceRepository;

        #endregion

        #region Ctor

        public PriceService(IRepository<DistancePrice> distancePriceRepository, IRepository<VolumePrice> volumePriceRepository)
        {
            _distancePriceRepository = distancePriceRepository;
            _volumePriceRepository = volumePriceRepository;
        }

        #endregion

        #region Distance pricing

        public List<DistancePriceModel> GetAllDistancePrices()
        {
            var prices = _distancePriceRepository.GetAll().ToList();

            return prices.Select(x => x.ToModel<DistancePriceModel, DistancePrice>()).ToList();
        }

        #endregion

        #region Volume pricing

        public List<VolumePriceModel> GetAllVolumePrices()
        {
            var prices = _volumePriceRepository.GetAll().ToList();

            return prices.Select(x => x.ToModel<VolumePriceModel, VolumePrice>()).ToList();
        }

        #endregion
    }
}
