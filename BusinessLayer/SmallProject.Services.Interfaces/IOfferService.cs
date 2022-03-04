using SmallProject.Models;
using System;
using System.Collections.Generic;

namespace SmallProject.Services.Interfaces
{
    public interface IOfferService
    {
        /// <summary>
        /// User's offers are returned as a result
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<OfferModel> GetOffersByUser(string username);

        /// <summary>
        /// Create an offer with calculated price
        /// </summary>
        /// <param name="model"></param>
        /// <param name="username"></param>
        void CreateOffer(CreateOfferModel model, string username);

        /// <summary>
        /// Get offer by ID for details view
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns></returns>
        DetailsOfferModel GetOfferById(Guid offerId);

        /// <summary>
        /// Check if the user can access the details of an offer
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        bool CheckUserAccessInOffer(Guid offerId, string username);
    }
}
