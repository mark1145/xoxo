using System;
using System.Collections.Generic;

namespace Ballicon.API.Models
{
    public partial class OrderDaysBooked
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? CleanerId { get; set; }
        public string Day { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public float? ActualHourlyRate { get; set; }

        public Cleaners Cleaner { get; set; }
        public Orders Order { get; set; }
    }
}
