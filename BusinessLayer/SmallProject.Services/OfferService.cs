using Microsoft.EntityFrameworkCore;
using SmallProject.AutoMapper;
using SmallProject.Data.Implementations;
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
        private readonly IRepository<Offer> _offerRepository;
        private readonly IRepository<User> _userRepository;

        #endregion

        #region Ctor

        public OfferService(IRepository<DistancePrice> distancePriceRepository,
                            IRepository<VolumePrice> volumePriceRepository,
                            IRepository<Offer> offerRepository,
                            IRepository<User> userRepository)
        {
            _distancePriceRepository = distancePriceRepository;
            _volumePriceRepository = volumePriceRepository;
            _offerRepository = offerRepository;
            _userRepository = userRepository;
        }

        #endregion

        public List<OfferModel> GetOffersByUser(string username)
        {
            var user = _userRepository.Query().FirstOrDefault(x => x.Username.ToLower() == username.ToLower());

            if (user == null)
                throw new Exception("The user does not exist!");

            var offers = _offerRepository.Query().Where(x => x.UserId == user.Id).ToList();

            return offers.Select(x => x.ToModel<OfferModel, Offer>()).ToList();
        }

        public void CreateOffer(CreateOfferModel model, string username)
        {
            var user = _userRepository.Query().FirstOrDefault(x => x.Username.ToLower() == username.ToLower());

            if (user == null)
                throw new Exception("The user does not exist!");

            var totalPrice = CalculatePrice(model);

            using (var unitOfWork = new UnitOfWork())
            {
                var domain = new Offer()
                {
                    Id = Guid.NewGuid(),
                    Distance = model.Distance,
                    LivingArea = model.LivingArea,
                    AtticArea = model.AtticArea,
                    PianoIncluded = model.PianoIncluded,
                    UserId = user.Id,
                    TotalPrice = totalPrice
                };

                _offerRepository.Create(domain);

                unitOfWork.SaveChanges();
            }
        }

        public DetailsOfferModel GetOfferById(Guid offerId)
        {
            var offer = _offerRepository.GetById(offerId);

            if (offer == null)
                throw new Exception("The offer does not exist!");

            return offer.ToModel<DetailsOfferModel, Offer>();
        }

        public bool CheckUserAccessInOffer(Guid offerId, string username)
        {
            var user = _userRepository.Query().FirstOrDefault(x => x.Username.ToLower() == username.ToLower());

            if (user == null)
                throw new Exception("The user does not exist!");

            var offer = _offerRepository.GetById(offerId);
            if (offer == null)
                throw new Exception("The offer does not exist!");

            if (offer.UserId == user.Id)
                return true;

            return false;
        }

        private int CalculatePrice(CreateOfferModel model)
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
