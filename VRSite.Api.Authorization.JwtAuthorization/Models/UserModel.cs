using System;

namespace VRSite.Api.Authorization.JwtAuthorization.Models
{
    public class UserModel
    {
        public DateTime LoginTime { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string OrganizationName { get; set; }

        public string Phone { get; set; }
        
        public int Id { get; set; }
    }
}
