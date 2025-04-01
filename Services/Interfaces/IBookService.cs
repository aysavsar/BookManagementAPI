using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;

namespace BookManagementAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookResponse?> GetByIdAsync(GetBookByIdRequest request);
        Task<BookResponse> UpdateAsync(UpdateBookRequest request);
    }
}