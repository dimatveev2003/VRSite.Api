namespace VRSite.Api.MailService.Models
{
    public class CreatedOrderModel
    {
        public int OrderId { get; set; }
        public string Price { get; set; }
        public int CountProducts { get; set; }
    }
}