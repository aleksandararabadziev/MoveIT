using System;

namespace SmallProject.Models
{
    public class OfferModel
    {
        public Guid Id { get; set; }

        public int Distance { get; set; }

        public int LivingArea { get; set; }

        public int AtticArea { get; set; }

        public bool PianoIncluded { get; set; }

        public Guid UserId { get; set; }

        public int TotalPrice { get; set; }
    }

    public class CreateOfferModel
    {
        public int Distance { get; set; }

        public int LivingArea { get; set; }

        public int AtticArea { get; set; }

        public bool PianoIncluded { get; set; }
    }

    public class DetailsOfferModel
    {
        public Guid Id { get; set; }

        public int Distance { get; set; }

        public int LivingArea { get; set; }

        public int AtticArea { get; set; }

        public bool PianoIncluded { get; set; }

        public string UserFullName { get; set; }

        public int TotalPrice { get; set; }
    }
}
