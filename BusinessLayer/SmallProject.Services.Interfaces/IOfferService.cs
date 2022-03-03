using SmallProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallProject.Services.Interfaces
{
    public interface IOfferService
    {
        /// <summary>
        /// Offer is created after the user asked for one
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CreateOffer(OfferModel model);
    }
}
