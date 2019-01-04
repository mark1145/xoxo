using System;
using System.Collections.Generic;

namespace Ballicon.API.Models
{
    public partial class CleanerAvailability
    {
        public int Id { get; set; }
        public int CleanerId { get; set; }
        public string Day { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }

        public Cleaners Cleaner { get; set; }
    }
}
