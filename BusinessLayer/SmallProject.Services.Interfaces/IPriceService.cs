using SmallProject.Models;
using System.Collections.Generic;

namespace SmallProject.Services.Interfaces
{
    public interface IPriceService
    {
        /// <summary>
        /// Returns all disance prices which can be used for offer price calculation
        /// </summary>
        /// <returns></returns>
        List<DistancePriceModel> GetAllDistancePrices();

        /// <summary>
        /// Returns all volume prices which can be used for offer price calculation
        /// </summary>
        /// <returns></returns>
        List<VolumePriceModel> GetAllVolumePrices();
    }
}
