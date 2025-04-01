using BookManagementAPI.Models.Requests;
using BookManagementAPI.Models.Responses;
using BookManagementAPI.Services.Interfaces;
using BookManagementAPI.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;
        private readonly IValidator<GetBookByIdRequest> _getValidator;
        private readonly IValidator<UpdateBookRequest> _updateValidator;
        private readonly IValidator<GetBookByIdRequest> _deleteValidator;

        public BooksController(
            IBookService bookService,
            ILogger<BooksController> logger,
            IValidator<GetBookByIdRequest> getValidator,
            IValidator<UpdateBookRequest> updateValidator,
            IValidator<GetBookByIdRequest> deleteValidator)
        {
            _bookService = bookService;
            _logger = logger;
            _getValidator = getValidator;
            _updateValidator = updateValidator;
            _deleteValidator = deleteValidator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BookResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetBookByIdRequest(id);
            var validation = await _getValidator.ValidateAsync(request);
            
            if (!validation.IsValid)
                return BadRequest(new ErrorResponse("ValidationError", 
                    string.Join(", ", validation.Errors.Select(e => e.ErrorMessage))));

            var book = await _bookService.GetByIdAsync(request);
            return book == null 
                ? NotFound(new ErrorResponse("NotFound", "Book not found")) 
                : Ok(book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BookResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequest request)
        {
            var validation = await _updateValidator.ValidateAsync(request);
            if (!validation.IsValid)
                return BadRequest(new ErrorResponse("ValidationError", 
                    string.Join(", ", validation.Errors.Select(e => e.ErrorMessage))));

            try
            {
                return Ok(await _bookService.UpdateAsync(request));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse("NotFound", ex.Message));
            }
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new GetBookByIdRequest(id);
            var validation = await _deleteValidator.ValidateAsync(request);
            
            if (!validation.IsValid)
                return BadRequest(new ErrorResponse("ValidationError", 
                    string.Join(", ", validation.Errors.Select(e => e.ErrorMessage))));

            return await _bookService.DeleteAsync(request) 
                ? NoContent() 
                : NotFound(new ErrorResponse("NotFound", "Book not found"));
        }
    }
}