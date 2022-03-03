using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallProject.Domain
{
    public class Offer
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Distance of the move
        /// </summary>
        [Required]
        public int Distance { get; set; }

        /// <summary>
        /// Square meters of the living area
        /// </summary>
        [Required]
        public int LivingArea { get; set; }

        /// <summary>
        /// Square meters of the attic area
        /// </summary>
        [Required]
        public int AtticArea { get; set; }

        /// <summary>
        /// Idicates if the move includes a piano
        /// </summary>
        [Required]
        public bool PianoIncluded { get; set; }

        /// <summary>
        /// Relation to the user who asked for an offer
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Object of the related user
        /// </summary>
        [ForeignKey("UserId")]
        public User User { get; set; }

        /// <summary>
        /// Price after the calculation was made
        /// </summary>
        public int TotalPrice { get; set; }
    }
}
