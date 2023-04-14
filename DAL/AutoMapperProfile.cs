using AutoMapper;
using DAL;
using Models;

namespace Seathub.DAL;

public class AutoMapperDALProfile : Profile
{
    public AutoMapperDALProfile()
    {
        /* USER */
        CreateMap<PlayerModel, Models.Player>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.playername, act => act.MapFrom(src => src.playername))
            .ForMember(dest => dest.score, act => act.MapFrom(src => src.score))
            .ForMember(dest => dest.playerpwd, act => act.MapFrom(src => src.playerpwd));

        CreateMap<Models.Player, PlayerModel>()
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.playername, act => act.MapFrom(src => src.playername))
            .ForMember(dest => dest.playerpwd, act => act.MapFrom(src => src.playerpwd))
            .ForMember(dest => dest.score, act => act.MapFrom(src => src.score));
    }
}