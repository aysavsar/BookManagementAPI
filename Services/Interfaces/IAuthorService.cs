using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookManagementAPI.Models.Dtos;

namespace BookManagementAPI.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(Guid id);
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<AuthorDto> UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto);
        Task<bool> DeleteAuthorAsync(Guid id);
    }
}
