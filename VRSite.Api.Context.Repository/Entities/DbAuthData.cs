namespace VRSite.Api.Context.Repository.Entities
{
    public class DbAuthData
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }
        public DbClient Client { get; set; }

        public string AccessToken { get; set; }
    }
}
