namespace BookManagementAPI.Models.Requests
{
    public record UpdateBookRequest(
        Guid Id,
        string Title,
        string Author,
        string? Description,
        int PublicationYear,
        string? Isbn,
        int PageCount);
}