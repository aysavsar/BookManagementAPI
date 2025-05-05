namespace BookManagementAPI.Models.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; } = string.Empty; // ya da null yapılabilir

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
