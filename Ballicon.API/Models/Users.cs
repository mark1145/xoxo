using System;
using System.Collections.Generic;

namespace Ballicon.API.Models
{
    public partial class Users
    {
        public Users()
        {
            Cleaners = new HashSet<Cleaners>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string KnownAs { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<Cleaners> Cleaners { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
