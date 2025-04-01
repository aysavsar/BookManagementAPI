namespace BookManagementAPI.Models.Responses
{
    public record BookResponse(
        Guid Id,
        string Title,
        string Author,
        string? Description,
        int PublicationYear,
        string? Isbn,
        int PageCount,
        DateTime CreatedAt,
        DateTime? UpdatedAt);
}