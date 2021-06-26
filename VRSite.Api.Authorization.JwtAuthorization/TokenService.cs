using System;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using VRSite.Api.Authorization.JwtAuthorization.Configurations;
using VRSite.Api.Authorization.JwtAuthorization.Contracts;
using VRSite.Api.Authorization.JwtAuthorization.Helpers;
using VRSite.Api.Authorization.JwtAuthorization.Models;

namespace VRSite.Api.Authorization.JwtAuthorization
{
    public class TokenService : ITokenService
    {
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserTokenModel GetToken(UserModel model)
        {
            var now = DateTime.UtcNow;
            var identity = IdentityHelper.GetIdentity(model);

            var jwt = new JwtSecurityToken(
                issuer: AuthOptionConfig.Issuer,
                audience: AuthOptionConfig.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptionConfig.TimeToLive)),
                signingCredentials: new SigningCredentials(AuthOptionConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var result = _mapper.Map<UserTokenModel>(token);

            result.ExpireIn = AuthOptionConfig.TimeToLive * 60;

            return result;
        }

        public UserModel GetUserModel()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var result = IdentityHelper.GetUserModelFromIdentity(user.Identity);

            return result;
        }
    }
}
