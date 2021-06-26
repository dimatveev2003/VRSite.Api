using System;
using System.Collections.Generic;

namespace VRSite.Api.Context.Repository.Entities
{
    public class DbClient
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationTime { get; set; }

        public string OrganizationName { get; set; }

        public string Phone { get; set; }
        
        public List<DbOrder> Orders { get; set; } = new List<DbOrder>();
    }
}
