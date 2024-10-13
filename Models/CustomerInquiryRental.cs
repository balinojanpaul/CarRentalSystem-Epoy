using System;

namespace CarRentalSystem2.Models
{
    public class CustomerInquiryRental
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public int? InquiryId { get; set; }
        public string InquiryStatus { get; set; }
        public int? RentalId { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public string RentalStatus { get; set; }
        public decimal? RentalTotalAmount { get; set; }
        public int? RentalCarId { get; set; }
    }
}