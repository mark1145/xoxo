using System;
using System.Collections.Generic;

namespace Ballicon.API.Models
{
    public partial class Cleaners
    {
        public Cleaners()
        {
            CleanerAvailability = new HashSet<CleanerAvailability>();
            OrderDaysBooked = new HashSet<OrderDaysBooked>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float? HourlyRate { get; set; }
        public string Postcode { get; set; }
        public int? RangeKm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Users User { get; set; }
        public ICollection<CleanerAvailability> CleanerAvailability { get; set; }
        public ICollection<OrderDaysBooked> OrderDaysBooked { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
