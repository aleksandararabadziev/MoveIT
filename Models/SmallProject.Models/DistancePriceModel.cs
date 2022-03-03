namespace SmallProject.Models
{
    public class DistancePriceModel
    {
        public int Id { get; set; }

        public int DistanceFrom { get; set; }

        public int? DistanceTo { get; set; }

        public int FixedPrice { get; set; }

        public int PricePerKm { get; set; }

        public int PianoPrice { get; set; }
    }
}
