namespace VRSite.Api.Business.ClientBusiness.Models.Responses
{
    public class LoginClientResponseModel
    {
        /// <summary>
        /// Токен пользщователя
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Когда токен истекает
        /// </summary>
        public int ExpireIn { get; set; }
    }
}
