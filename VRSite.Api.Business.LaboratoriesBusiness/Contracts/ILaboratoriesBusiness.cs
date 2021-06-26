using System.Threading.Tasks;
using VRSite.Api.Business.LaboratoriesBusiness.Models.Responses;

namespace VRSite.Api.Business.LaboratoriesBusiness.Contracts
{
    public interface ILaboratoriesBusiness
    {
        Task<GetAllLabsResponseModel> GetAllLabs();
        Task<GetAllBundlesResponseModel> GetAllBundles();
    }
}
