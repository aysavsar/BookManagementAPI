namespace BookManagementAPI.Models.Responses
{
    public record ErrorResponse(
        string ErrorCode,
        string Message,
        Dictionary<string, string>? Details = null);
}