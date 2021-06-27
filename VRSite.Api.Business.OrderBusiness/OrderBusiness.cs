using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRSite.Api.Authorization.JwtAuthorization.Contracts;
using VRSite.Api.Business.OrderBusiness.Contracts;
using VRSite.Api.Business.OrderBusiness.Enums;
using VRSite.Api.Business.OrderBusiness.Helpers;
using VRSite.Api.Business.OrderBusiness.Models.Requests;
using VRSite.Api.Business.OrderBusiness.Models.Responses;
using VRSite.Api.Context.Repository.Contracts;
using VRSite.Api.Context.Repository.Entities;
using VRSite.Api.MailService.Contracts;
using VRSite.Api.MailService.Models;

namespace VRSite.Api.Business.OrderBusiness
{
    public class OrderBusiness : IOrderBusiness
    {
        
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        private readonly ITokenService _tokenService;

        private readonly IMailService _mailService;

        public OrderBusiness(IRepository repository, IMapper mapper, ITokenService tokenService, IMailService mailService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
            _mailService = mailService;
        }

        public async Task<CreateOrderResponseModel> CreateOrder(CreateOrderRequestModel requestModel)
        {
            var user = _tokenService.GetUserModel();
            
            var client = await _repository.Clients.FirstAsync(c => c.Id == user.Id);
            var currency = await _repository.Currencies.FirstAsync(c => c.Id == requestModel.CurrencyId);

            var order = OrderHelper.GetDbOrder(requestModel, client, currency);
            await _repository.Orders.AddAsync(order);
            await _repository.SaveDbChangesAsync();

            foreach (var item in requestModel.OrderItems)
            {
                switch (item.Type)
                {
                    case ProductType.Laboratory:
                    {
                        var lab = await _repository.Laboratories.FirstAsync(l => l.Id == item.Id);
                        var added = await _repository.LaboratoryOrderItems.AddAsync(new DbLaboratoryOrderItem
                            {Order = order, Laboratory = lab});
                        
                        break;
                    }
                    case ProductType.Bundle:
                    {
                        var bundle = await _repository.Bundles.FirstAsync(b => b.Id == item.Id);
                        await _repository.BundleOrderItems.AddAsync(new DbBundleOrderItem
                            {Order = order, Bundle = bundle});
                        
                        break;
                    }

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            await _repository.SaveDbChangesAsync();

            var userModel = new UserModel
            {
                Email = user.Email,
                Phone = user.Phone,
                Id = user.Id,
                Login = user.Login,
                OrganizationName = user.OrganizationName
            };

            var createdOrder = new CreatedOrderModel
            {
                CountProducts = requestModel.OrderItems.Length,
                Price = $"{requestModel.Amount} {currency.CurrencySymbol}",
                OrderId = order.Id
            };

            await _mailService.SendOrderCreatedMailToManager(userModel, createdOrder);

            return new CreateOrderResponseModel {IsSuccess = true, OrderId = order.Id};
        }
    }
}