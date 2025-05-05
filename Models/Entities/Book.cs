using System;

namespace BookManagementAPI.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; } // Author sınıfı eklendi
        public int PublicationYear { get; set; } // PublicationYear eklendi
        public int PageCount { get; set; } // PageCount eklendi
        public DateTime CreatedAt { get; set; } // CreatedAt eklendi
        public DateTime? UpdatedAt { get; set; }
        // Genre ile ilişki
        public Guid GenreId { get; set; }  
        public Genre Genre { get; set; }
    }
}
