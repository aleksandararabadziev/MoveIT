using System.ComponentModel.DataAnnotations;

namespace SmallProject.Domain
{
    /// <summary>
    /// Domain class used to access the DistancePrices data table
    /// </summary>
    public class DistancePrice
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Represents the start of the distance range
        /// </summary>
        [Required]
        public int DistanceFrom { get; set; }

        /// <summary>
        /// Represents the end of the distance range
        /// </summary>
        public int? DistanceTo { get; set; }

        /// <summary>
        /// Fixed price for the distance
        /// </summary>
        [Required]
        public int FixedPrice { get; set; }

        /// <summary>
        /// Variable price per kilometer
        /// </summary>
        [Required]
        public int PricePerKm { get; set; }

        /// <summary>
        /// Fixed prices for moving a piano
        /// </summary>
        [Required]
        public int PianoPrice { get; set; }
    }
}
