using System;
using System.Collections.Generic;

namespace Ballicon.API.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDaysBooked = new HashSet<OrderDaysBooked>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CleanerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Days { get; set; }
        public bool? PaymentSuccessful { get; set; }
        public string PaymentMethod { get; set; }

        public Cleaners Cleaner { get; set; }
        public Users User { get; set; }
        public ICollection<OrderDaysBooked> OrderDaysBooked { get; set; }
    }
}
