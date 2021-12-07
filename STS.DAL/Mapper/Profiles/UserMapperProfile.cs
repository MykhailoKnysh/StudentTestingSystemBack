﻿using System.Linq;
using AutoMapper;
using STS.Common.Auth.Models;
using STS.Common.Models;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.Mapper.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMapUserEntityToUser();
            CreateMapUserToAuthModelForCreateToken();
        }

        private void CreateMapUserEntityToUser()
        {
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt
                    .MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt
                    .MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt
                    .MapFrom(src => src.Email))
                .ForMember(dest => dest.Role, opt => opt
                    .MapFrom(src => src.Role))
                .ForMember(dest => dest.GroupIds, opt => opt
                    .MapFrom(src => src.Groups.Select(g => g.Id)));
        }

        private void CreateMapUserToAuthModelForCreateToken()
        {
            CreateMap<User, AuthModelForCreateToken>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt
                    .MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt
                    .MapFrom(src => src.Email));
        }
    }
}