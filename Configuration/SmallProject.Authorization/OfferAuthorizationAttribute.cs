using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SmallProject.Services.Interfaces;
using System;

namespace SmallProject.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OfferAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IOfferService _offerService;

        public OfferAuthorizationAttribute(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var user = request.Headers["user"];
            var queryString = request.QueryString.Value;
            var offerId = !string.IsNullOrEmpty(queryString) ? Guid.Parse(queryString.Replace("?offerId=", "")) : (Guid?)null;

            var accesGranted = _offerService.CheckUserAccessInOffer(offerId.Value, user);

            if (!accesGranted)
                throw new Exception("Access denied for user " + user + " for offer with ID " + offerId);
        }
    }
}
