namespace BookManagementAPI.Models.Dtos
{
    public class AuthorDto
    {
         public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;  // Required özellik
        public string Biography { get; set; } = string.Empty;  // Required özellik
    }
}
