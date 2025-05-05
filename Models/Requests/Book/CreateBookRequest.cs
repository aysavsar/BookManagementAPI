using System;

namespace BookManagementAPI.Requests.Book
{
    public record CreateBookRequest(
        string Title,
        Guid AuthorId,
        Guid GenreId,
        bool IsPublished);
}