using System.Collections.Generic;
using System.Threading.Tasks;
using BookManagementAPI.Models.Dtos;

namespace BookManagementAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createDto);
        Task<AuthorDto> UpdateAuthorAsync(int id, UpdateAuthorDto updateDto);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
