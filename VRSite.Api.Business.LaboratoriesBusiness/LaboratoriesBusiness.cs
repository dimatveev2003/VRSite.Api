using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VRSite.Api.Business.LaboratoriesBusiness.Contracts;
using VRSite.Api.Business.LaboratoriesBusiness.Models;
using VRSite.Api.Business.LaboratoriesBusiness.Models.Responses;
using VRSite.Api.Context.Repository.Contracts;

namespace VRSite.Api.Business.LaboratoriesBusiness
{
    public class LaboratoriesBusiness : ILaboratoriesBusiness
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        public LaboratoriesBusiness(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<GetAllBundlesResponseModel> GetAllBundles()
        {
            var dbBundles = _repository.Bundles
                .Include(bundle => bundle.Prices)
                    .ThenInclude(p => p.Currency)
                .Include(bundle => bundle.Laboratories)
                    .ThenInclude(lab => lab.Prices).ToListAsync().Result;

            var bundles = _mapper.Map<List<BundleModel>>(dbBundles);
            var result = new GetAllBundlesResponseModel { Bundles = bundles };

            return Task.FromResult(result);
        }

        public Task<GetAllLabsResponseModel> GetAllLabs()
        {
            var labs = _repository.Laboratories.Include(lab => lab.Prices).ThenInclude(p => p.Currency).ToListAsync().Result;

            var laboratories = _mapper.Map<List<ShortLaboratoryModel>>(labs);
            var result = new GetAllLabsResponseModel { Laboratories = laboratories };

            return Task.FromResult(result);
        }
    }
}
