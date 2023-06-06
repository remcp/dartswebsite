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
            .ForMember(dest => dest.id, act => act.MapFrom(src => src.Player_id))
            .ForMember(dest => dest.playername, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.score, act => act.MapFrom(src => src.Score))
            .ForMember(dest => dest.playerpwd, act => act.MapFrom(src => src.Password));

        CreateMap<Models.Player, PlayerModel>()
            .ForMember(dest => dest.Player_id, act => act.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.playername))
            .ForMember(dest => dest.Password, act => act.MapFrom(src => src.playerpwd))
            .ForMember(dest => dest.Score, act => act.MapFrom(src => src.score));

        /* Game */
        CreateMap<GameModel, Models.Game>()
            .ForMember(dest => dest.Game_id, act => act.MapFrom(src => src.Game_id))
            .ForMember(dest => dest.gamemode, act => act.MapFrom(src => src.gamemode));

        CreateMap<Models.Game, GameModel>()
            .ForMember(dest => dest.Game_id, act => act.MapFrom(src => src.Game_id))
            .ForMember(dest => dest.gamemode, act => act.MapFrom(src => src.gamemode));
    }
}