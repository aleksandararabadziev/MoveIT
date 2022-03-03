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
            CreateMap<User, UserModel>().ForMember(x => x.FullName, o => o.MapFrom(x => x.FirstName + " " + x.LastName));
            CreateMap<DistancePrice, DistancePriceModel>().ReverseMap();
            CreateMap<VolumePrice, VolumePriceModel>().ReverseMap();
        }
    }
}
