using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace VRSite.Api.Authorization.JwtAuthorization.Configurations
{
    public class AuthOptionConfig
    {
        /// <summary>
        /// Издатель токена
        /// <remarks>
        /// Надо вынести в конфиг, а вообще должен быть адресс где хостится апи
        /// </remarks>
        /// </summary>
        public const string Issuer = "muctr-authorization-server";

        /// <summary>
        /// Потребитель токена
        /// </summary>
        public const string Audience = "*";

        /// <summary>
        /// Ключ для шифра
        /// </summary>
        private const string Key = "mysupersecret_secretkey!123";

        /// <summary>
        /// Время жизни токена в минутах
        /// </summary>
        public const int TimeToLive = 30;

        /// <summary>
        /// получить симетричный ключ
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
