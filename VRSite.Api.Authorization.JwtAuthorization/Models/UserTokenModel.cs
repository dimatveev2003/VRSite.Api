namespace VRSite.Api.Authorization.JwtAuthorization.Models
{
    public class UserTokenModel
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
