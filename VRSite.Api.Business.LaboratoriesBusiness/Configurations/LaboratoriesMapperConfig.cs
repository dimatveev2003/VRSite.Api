using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VRSite.Api.Business.LaboratoriesBusiness.Models;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Business.LaboratoriesBusiness.Configurations
{
    public static class LaboratoriesMapperConfig
    {
        public static void SetMapperConfig(IMapperConfigurationExpression expression)
        {
            MapEntityModels(expression);
        }

        private static void MapEntityModels(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<DbPrice, PriceModel>();
            expression.CreateMap<DbCurrency, CurrencyModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName.Trim()));
            expression.CreateMap<DbLaboratory, LaboratoryModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section.Trim()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Trim()))
                .ForMember(dest => dest.FileDownloadLink, opt => opt.MapFrom(src => src.FileDownloadLink.Trim()))
                .ForMember(dest => dest.VideoId, opt => opt.MapFrom(src => src.VideoId.Trim()));

            expression.CreateMap<DbLaboratory, ShortLaboratoryModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section.Trim()))
                .ForMember(dest => dest.VideoId, opt => opt.MapFrom(src => src.VideoId.Trim()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Trim()));

            expression.CreateMap<DbBundle, BundleModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Trim()));
        }
    }
}
