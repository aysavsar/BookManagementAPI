using AutoMapper;
using BookManagementAPI.Data;
using BookManagementAPI.Models.Entities;
using BookManagementAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await _context.Authors
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<AuthorDto>(author); // Eğer null dönebilirse, null kontrolü yapın
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<AuthorDto> UpdateAuthorAsync(Guid id, UpdateAuthorDto dto)
        {
            var author = await _context.Authors
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (author == null) return null; // Null kontrolü ekledik

            _mapper.Map(dto, author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> DeleteAuthorAsync(Guid id)
        {
            var author = await _context.Authors
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
