using AutoMapper;
using BookManagementAPI.Data;
using BookManagementAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagementAPI.Models.Dtos;



namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound("Yazar bulunamadı");

            _mapper.Map(dto, author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
                return NotFound("Yazar bulunamadı");

            if (author.Books.Any())
                return BadRequest("Yayında kitabı olan bir yazar silinemez.");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(_mapper.Map<List<AuthorDto>>(authors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound("Yazar bulunamadı");

            return Ok(_mapper.Map<AuthorDto>(author));
        }
    }
}
