using AutoMapper;
using BookManagementAPI.Models.Entities;
using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;
using BookManagementAPI.Services.Interfaces;

namespace BookManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly List<Book> _books = new(); 
        
        public BookService(IMapper mapper)
        {
            _mapper = mapper;
            
            // Seed data
            _books.Add(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Clean Code",
                Author = "Robert C. Martin",
                PublicationYear = 2008,
                PageCount = 464,
                CreatedAt = DateTime.UtcNow
            });
        }
        
        public async Task<BookResponse?> GetByIdAsync(GetBookByIdRequest request)
        {
            var book = _books.FirstOrDefault(b => b.Id == request.Id);
            return book == null ? null : _mapper.Map<BookResponse>(book);
        }
        
        public async Task<BookResponse> UpdateAsync(UpdateBookRequest request)
        {
            var book = _books.FirstOrDefault(b => b.Id == request.Id);
            if (book == null) throw new KeyNotFoundException("Book not found");
            
            _mapper.Map(request, book);
            book.UpdatedAt = DateTime.UtcNow;
            
            return _mapper.Map<BookResponse>(book);
        }
    }
}