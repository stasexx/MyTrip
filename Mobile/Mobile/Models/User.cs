using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class User
    {
        public int userId { get; set; }

        public string password { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public bool orgRights { get; set; }
        public string agency { get; set; }
        public int experience { get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string city { get; set; }
        public string avatar { get; set; }
        public bool availabilityOfTours { get; set; }
        public bool availabilityOfProfile { get; set; }
        public bool isBanned { get; set; }
        public DateTime regDate { get; set; }
    }
}
