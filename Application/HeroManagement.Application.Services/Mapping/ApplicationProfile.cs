using AutoMapper;
using HeroManagement.Application.Models.Ability;
using HeroManagement.Application.Models.Admin;
using HeroManagement.Application.Models.Hero;
using HeroManagement.Application.Models.Item;
using HeroManagement.Application.Models.Player;
using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Application.Services.Mapping;

public class ApplicationProfile : Profile
{
    ApplicationProfile()
    {
        CreateMap<Player, PlayerModel>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.Username.Value))
            .ForMember(dest => dest.ObservedItems,
                opt => opt.MapFrom(src => src.ObservableItems))
            .ForMember(dest => dest.ObservedHeroes,
                opt => opt.MapFrom(src => src.ObservableHeroes))
            .ForMember(dest => dest.ObservedAbilities,
                opt => opt.MapFrom(src => src.ObservableAbilities));

        CreateMap<Admin, AdminModel>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.Username.Value));
            // .ForMember(dest => dest.Items,
            //     opt => opt.MapFrom(src => src.ActiveItem))
            // .ForMember(dest => dest.Heroes,
            //     opt => opt.MapFrom(src => src.ActiveHero))
            // .ForMember(dest => dest.Abilities,
            //     opt => opt.MapFrom(src => src.ActiveAbility));

        CreateMap<Hero, HeroModel>()
            .ForMember(dest => dest.ObjectName,
                opt => opt.MapFrom(src => src.HeroName.Value));
            // .ForMember(dest => dest.AdminId,
            //     opt => opt.MapFrom(src => src.Admin.Id));
            CreateMap<Item, ItemModel>()
                .ForMember(dest => dest.ObjectName,
                    opt => opt.MapFrom(src => src.ItemName.Value));
            // .ForMember(dest => dest.AdminId,
            //     opt => opt.MapFrom(src => src.Admin.Id));
            CreateMap<Ability, AbilityModel>()
                .ForMember(dest => dest.ObjectName,
                    opt => opt.MapFrom(src => src.AbilityName.Value));
            // .ForMember(dest => dest.AdminId,
            //     opt => opt.MapFrom(src => src.Admin.Id));
    }

}