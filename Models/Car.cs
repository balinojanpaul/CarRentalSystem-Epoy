namespace CarRentalSystem2.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public bool Availability { get; set; }
        public string ImagePath { get; set; }
    }
}