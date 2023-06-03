using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class User
    {

        public string Password { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public bool OrgRights { get; set; }

        public string Agency { get; set; }

        public int Expirience { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Avatar { get; set; }

        public bool AvailabilityOfTours { get; set; }

        public bool AvailabilityOfProfile { get; set; }

        public bool IsBanned { get; set; }

        public DateTime RegDate { get; set; }
    }
}
