using System;
 
 namespace CarRentalSystem2.Models
 {
     public class Payment
     {
         public int PaymentId { get; set; }
         public int RentalId { get; set; }
         public decimal PaymentAmount { get; set; }
         public DateTime PaymentDate { get; set; }
     }
 }