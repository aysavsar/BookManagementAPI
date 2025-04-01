using AutoMapper;
using BookManagementAPI.Models.Entities;
using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;

namespace BookManagementAPI.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<UpdateBookRequest, Book>();
            CreateMap<Book, BookResponse>();
        }
    }
}