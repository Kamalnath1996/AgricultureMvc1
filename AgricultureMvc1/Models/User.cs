using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgricultureMvc1.Models
{
    public class User
    {
        internal object number;

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string roleId { get; set; }
        public string createdOn { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }
    }
}