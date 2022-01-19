﻿using AutoMapper;
using STS.Common.Models;
using STS.DAL.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class SubjectMapperProfile : Profile
    {
        public SubjectMapperProfile()
        {
            CreateMapSubjectEntityToSubject();
            CreateMapSubjectToSubjectEntity();
        }

        private void CreateMapSubjectEntityToSubject()
        {
            CreateMap<Subject, SubjectEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title));
        }

        private void CreateMapSubjectToSubjectEntity()
        {
            CreateMap<SubjectEntity, Subject>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title));
        }
    }
}