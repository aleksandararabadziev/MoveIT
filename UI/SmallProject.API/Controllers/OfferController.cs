using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallProject.Authorization;
using SmallProject.Models;
using SmallProject.Services.Interfaces;
using System;

namespace SmallProject.API.Controllers
{
    public class OfferController : Controller
    {

        #region Declarations

        private readonly IOfferService _offerService;

        #endregion

        #region Ctor

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        #endregion

        [HttpGet]
        public JsonResult GetAllOffersByUser()
        {
            var username = Request.Headers["user"];
            var offers = _offerService.GetOffersByUser(username);
            return Json(offers);
        }

        [HttpPost]
        public JsonResult CreateOffer([FromBody] CreateOfferModel model)
        {
            var username = Request.Headers["user"];
            _offerService.CreateOffer(model, username);
            return Json(true);
        }

        [TypeFilter(typeof(OfferAuthorizationAttribute))]
        [HttpGet]
        public JsonResult GetOfferById(Guid offerId)
        {
            var username = Request.Headers["user"];
            var offer = _offerService.GetOfferById(offerId);
            return Json(offer);
        }
    }
}
