﻿using AutoMapper;
using Common.Models;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class ThemeMapperProfile : Profile
    {
        public ThemeMapperProfile()
        {
            CreateMapThemeEntityToTheme();
            CreateMapThemeToThemeEntity();
        }

        private void CreateMapThemeEntityToTheme()
        {
            CreateMap<ThemeEntity, Theme>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title))
                .ForMember(dest => dest.Subject, opt => opt
                    .MapFrom(src => src.Subject));
        }

        private void CreateMapThemeToThemeEntity()
        {
            CreateMap<Theme, ThemeEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title))
                .ForMember(dest => dest.SubjectId, opt => opt
                    .MapFrom(src => src.Subject.Id));
        }
    }
}
