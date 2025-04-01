using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;
using BookManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        
        public BooksController(
            IBookService bookService,
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var request = new GetBookByIdRequest(id);
                var book = await _bookService.GetByIdAsync(request);
                
                return book == null 
                    ? NotFound(new ErrorResponse("NotFound", "Book not found")) 
                    : Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting book by ID");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse("ServerError", "An unexpected error occurred"));
            }
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequest request)
        {
            try
            {
                var updatedBook = await _bookService.UpdateAsync(request);
                return Ok(updatedBook);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse("NotFound", ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating book");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponse("ServerError", "An unexpected error occurred"));
            }
        }
    }
}