using AutoMapper;
using UI.Models;
using Models;
using DAL;

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

        /* Game */
        CreateMap<GameViewModel, Models.Game>()
            .ForMember(dest => dest.Game_id, act => act.MapFrom(src => src.Game_id))
            .ForMember(dest => dest.gamemode, act => act.MapFrom(src => src.gamemode));

        CreateMap<Models.Game, GameViewModel>()
            .ForMember(dest => dest.Game_id, act => act.MapFrom(src => src.Game_id))
            .ForMember(dest => dest.gamemode, act => act.MapFrom(src => src.gamemode));
    }
}