using AutoMapper;
using SmallProject.Domain;
using SmallProject.Models;
using SmallProject.Settings;

namespace SmallProject.AutoMapper
{
    public class RegisterMappers : Profile
    {
        public RegisterMappers()
        {
            CreateMap<AppSettings, AppSettingsModel>();
            CreateMap<DistancePrice, DistancePriceModel>().ReverseMap();
            CreateMap<VolumePrice, VolumePriceModel>().ReverseMap();
        }
    }
}
