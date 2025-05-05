using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;
using System.Threading.Tasks;

namespace BookManagementAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookResponse?> GetByIdAsync(GetBookByIdRequest request);
        Task<BookResponse> UpdateAsync(UpdateBookRequest request);
        Task<bool> DeleteAsync(GetBookByIdRequest request);  // Bu satır eklendi
    }
}
