namespace VRSite.Api.Business.ClientBusiness.Models.Requests
{
    public class RegisterClientRequestModel
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string OrganizationName { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }
}
