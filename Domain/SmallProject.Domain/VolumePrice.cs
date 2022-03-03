using System.ComponentModel.DataAnnotations;

namespace SmallProject.Domain
{
    /// <summary>
    /// Domain class used to access the VolumePrices data table
    /// </summary>
    public class VolumePrice
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Maximum area per car
        /// </summary>
        [Required]
        public int MaximumArea { get; set; }

        /// <summary>
        /// Multiplier used to calculate the price for the attic area
        /// </summary>
        [Required]
        public int AtticAreaMultiplier { get; set; }

        /// <summary>
        /// Fixed price per car
        /// </summary>
        [Required]
        public int PricePerCar { get; set; }
    }
}
