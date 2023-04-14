using AutoMapper;
using dartwebsite.models;
using Models;

namespace Seathub.DAL;

public class AutoMapperDALProfile : Profile
{
    public AutoMapperDALProfile()
    {
        /* USER */
        CreateMap<PlayerViewModel, Models.Player>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.playername, act => act.MapFrom(src => src.playername))
            .ForMember(dest => dest.score, act => act.MapFrom(src => src.score))
            .ForMember(dest => dest.playerpwd, act => act.MapFrom(src => src.playerpwd));

        CreateMap<Models.Player, PlayerViewModel>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.playername, act => act.MapFrom(src => src.playername))
            .ForMember(dest => dest.playerpwd, act => act.MapFrom(src => src.playerpwd))
            .ForMember(dest => dest.score, act => act.MapFrom(src => src.score));
    }
}