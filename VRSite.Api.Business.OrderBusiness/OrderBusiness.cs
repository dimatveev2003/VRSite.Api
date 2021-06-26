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

namespace VRSite.Api.Business.OrderBusiness
{
    public class OrderBusiness : IOrderBusiness
    {
        
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        private readonly ITokenService _tokenService;

        public OrderBusiness(IRepository repository, IMapper mapper, ITokenService tokenService)
        {
            _repository = repository;
            _mapper = mapper;
            _tokenService = tokenService;
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

            return new CreateOrderResponseModel {IsSuccess = true, OrderId = order.Id};
        }
    }
}