using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRSite.Api.Authorization.JwtAuthorization.Contracts;
using VRSite.Api.Authorization.JwtAuthorization.Models;
using VRSite.Api.Business.ClientBusiness.Contracts;
using VRSite.Api.Business.ClientBusiness.Helpers;
using VRSite.Api.Business.ClientBusiness.Models.Requests;
using VRSite.Api.Business.ClientBusiness.Models.Responses;
using VRSite.Api.Common.WebApiBase.Exceptions;
using VRSite.Api.Context.Repository.Contracts;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Business.ClientBusiness
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        private readonly ITokenService _tokenService;

        public ClientBusiness(IRepository repository, IMapper mapper, ITokenService tokenService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<RegisterClientResponseModel> RegisterClient(RegisterClientRequestModel model)
        {
            var pwdHash = PasswordHashHelper.CreatePasswordHash(model.Password);

            var client = ClientHelper.GetDbClient(model, _mapper);
            await _repository.Clients.AddAsync(client);
            await _repository.SaveDbChangesAsync();

            await _repository.AuthData.AddAsync(new DbAuthData {AccessToken = pwdHash, Client = client});
            await _repository.SaveDbChangesAsync();

            return new RegisterClientResponseModel { IsSuccess = true };
        }

        public async Task<LoginClientResponseModel> LoginClient(LoginClientRequestModel model)
        {
            var pwdHash = PasswordHashHelper.CreatePasswordHash(model.Password);

            var authData = await
                _repository.AuthData.FirstOrDefaultAsync(data => data.AccessToken == pwdHash && data.Client.Login == model.Login);

            if (authData == null)
            {
                throw new ExceptionBase("Логин или пароль введены неверно");
            }

            var clientInfo = await _repository.Clients.FirstOrDefaultAsync(client => client.Id == authData.ClientId);

            var userModel = ClientHelper.GetUserModel(clientInfo, _mapper);

            var tokenModel = _tokenService.GetToken(userModel);

            var result = _mapper.Map<LoginClientResponseModel>(tokenModel);

            return result;
        }

        public async Task<UserModel> GetClientInfo()
        {
            var user = _tokenService.GetUserModel();
            var client = await _repository.Clients.FirstOrDefaultAsync(c => c.Id == user.Id);
            var result = ClientHelper.GetUserModel(client, _mapper);
    
            return result;
        }

        public async Task<SaveClientInfoResponseModel> SaveClientInfo(SaveClientInfoRequestModel model)
        {
            var user = _tokenService.GetUserModel();
            var client = await _repository.Clients.FirstOrDefaultAsync(c => c.Id == user.Id);
            if (client != null)
            {
                client.Email = model.Email;
                client.Phone = model.Phone;
            }

            await _repository.SaveDbChangesAsync();

            return new SaveClientInfoResponseModel
            {
                IsSuccess = true
            };
        }

        public async Task<ChangePasswordResponseModel> ChangePassword(ChangePasswordRequestModel model)
        {
            var user = _tokenService.GetUserModel();
            var authData = await _repository.AuthData.FirstOrDefaultAsync(auth => auth.ClientId == user.Id);
            var pwdHash = PasswordHashHelper.CreatePasswordHash(model.NewPassword);
            
            authData.AccessToken = pwdHash;
            await _repository.SaveDbChangesAsync();
            
            var clientInfo = await _repository.Clients.FirstOrDefaultAsync(client => client.Id == authData.ClientId);

            var newUserModel = ClientHelper.GetUserModel(clientInfo, _mapper);
            var tokenModel = _tokenService.GetToken(newUserModel);
            
            return new ChangePasswordResponseModel {IsSuccess = true, TokenModel = tokenModel};
        }
    }
}
