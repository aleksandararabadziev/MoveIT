using SmallProject.Data.Interfaces;
using SmallProject.Domain;
using SmallProject.Models;
using SmallProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallProject.Services
{
    public class OfferService : IOfferService
    {
        #region Declarations

        private readonly IRepository<DistancePrice> _distancePriceRepository;
        private readonly IRepository<VolumePrice> _volumePriceRepository;

        #endregion

        #region Ctor

        public OfferService(IRepository<DistancePrice> distancePriceRepository, IRepository<VolumePrice> volumePriceRepository)
        {
            _distancePriceRepository = distancePriceRepository;
            _volumePriceRepository = volumePriceRepository;
        }

        #endregion

        public int CreateOffer(OfferModel model)
        {
            var totalPrice = 0;

            var distancePrice = _distancePriceRepository.Query().FirstOrDefault(x => x.DistanceFrom <= model.Distance && (!x.DistanceTo.HasValue || (x.DistanceTo.HasValue && x.DistanceTo.Value >= model.Distance)));
            var volumePrice = _volumePriceRepository.Query().FirstOrDefault();

            var totalVolume = model.LivingArea + volumePrice.AtticAreaMultiplier * model.AtticArea;
            var cars = (int)Math.Ceiling((decimal)totalVolume / (decimal)volumePrice.MaximumArea);

            totalPrice = (distancePrice.FixedPrice + model.Distance * distancePrice.PricePerKm) + (cars * volumePrice.PricePerCar);

            if (model.PianoIncluded)
                totalPrice += distancePrice.PianoPrice;

            return totalPrice;
        }
    }
}
