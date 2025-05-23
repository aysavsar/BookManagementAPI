using AutoMapper;
using BookManagementAPI.Models.Entities;
using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;
using BookManagementAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly List<Book> _books = new();

        public BookService(IMapper mapper)
        {
            _mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            _books.Add(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Clean Code",
                Author = new Author
                {
                    FirstName = "Robert",
                    LastName = "C. Martin"
                },
                PublicationYear = 2008,
                PageCount = 464,
                CreatedAt = DateTime.UtcNow
            });
        }

        public async Task<BookResponse?> GetByIdAsync(GetBookByIdRequest request)
        {
            await Task.CompletedTask;
            var book = _books.FirstOrDefault(b => b.Id == request.Id);
            return book == null ? null : _mapper.Map<BookResponse>(book);
        }

        public async Task<BookResponse> UpdateAsync(UpdateBookRequest request)
        {
            await Task.CompletedTask;
            var book = _books.FirstOrDefault(b => b.Id == request.Id)
                ?? throw new KeyNotFoundException("Book not found");

            _mapper.Map(request, book);
            book.UpdatedAt = DateTime.UtcNow;

            return _mapper.Map<BookResponse>(book);
        }

        public async Task<bool> DeleteAsync(GetBookByIdRequest request)
        {
            await Task.CompletedTask;
            var book = _books.FirstOrDefault(b => b.Id == request.Id);
            return book != null && _books.Remove(book);
        }
    }
}
