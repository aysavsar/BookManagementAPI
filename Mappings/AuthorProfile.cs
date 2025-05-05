using AutoMapper;
using BookManagementAPI.Models;
using BookManagementAPI.Models.Dtos;
using BookManagementAPI.Models.Entities;

namespace BookManagementAPI.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
        }
    }
}
