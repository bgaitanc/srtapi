using System;
using System.Collections.Generic;

namespace SRT.Domain.Models.Dtos.Reservations
{
    public class ReservationValidationResult
    {
        public bool IsValid { get; set; }
        public Guid ReservationId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public List<short> SeatNumbers { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

