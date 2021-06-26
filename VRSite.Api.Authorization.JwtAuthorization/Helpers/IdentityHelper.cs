using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using VRSite.Api.Authorization.JwtAuthorization.Models;
using VRSite.Api.Common.WebApiBase.Exceptions;

namespace VRSite.Api.Authorization.JwtAuthorization.Helpers
{
    public static class IdentityHelper
    {
        public static ClaimsIdentity GetIdentity(UserModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(model.Id), model.Id.ToString()),
                new Claim(nameof(model.Login), model.Login),
                new Claim(nameof(model.Email), model.Email),
                new Claim(nameof(model.OrganizationName), model.OrganizationName),
                new Claim(nameof(model.Phone), model.Phone),
                new Claim(nameof(model.LoginTime), model.LoginTime.ToString(CultureInfo.InvariantCulture))
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
        
        /// <summary>
        /// Получить модель пользователя из объкета IIdentity
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static UserModel GetUserModelFromIdentity(IIdentity identity)
        {
            if (!(identity is ClaimsIdentity claimsIdentity && IsValidClaim(claimsIdentity)))
                throw new UnauthorizedException();

            var user = new UserModel();

            user.Id = Convert.ToInt32(GetValue(claimsIdentity, nameof(user.Id)).Trim());
            user.Login = GetValue(claimsIdentity, nameof(user.Login)).Trim();
            user.Email = GetValue(claimsIdentity, nameof(user.Email)).Trim();
            user.Phone = GetValue(claimsIdentity, nameof(user.Phone)).Trim();
            user.OrganizationName = GetValue(claimsIdentity, nameof(user.OrganizationName)).Trim();
            var loginTime = DateTimeOffset.ParseExact(GetValue(claimsIdentity, nameof(user.LoginTime)), "MM/dd/yyyy HH:mm:ss", null).Date;
            user.LoginTime = loginTime;

            return user;
        }
        
        /// <summary>
        /// Проверить заявку
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        private static bool IsValidClaim(ClaimsIdentity identity)
        {
            var result = identity.Claims.Any(clm => string.Equals(clm.Type, "OrganizationName", StringComparison.OrdinalIgnoreCase));

            return result;
        }
        
        /// <summary>
        /// Получить доп информацию
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetValue(ClaimsIdentity identity, string key)
        {
            var claims = identity.Claims;
            return claims.First(clm => string.Equals(key, clm.Type, StringComparison.CurrentCultureIgnoreCase)).Value;
        }
    }
}
