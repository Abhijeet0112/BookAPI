using Microsoft.AspNetCore.Mvc;
using BooksAPI.Models;       // Import your models namespace
using BooksAPI.Data;         // Import your DbContext namespace
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Required for async operations like ToListAsync()

namespace BooksAPI.Controllers
{
    // Defines the base route for this API controller.
    // Requests to /api/Books will be handled by this controller.
    [Route("api/[controller]")]
    [ApiController] // Indicates that this controller responds to web API requests.
    public class BooksController : ControllerBase // Inherit from ControllerBase for API controllers
    {
        // Private field to hold the database context.
        private readonly ApplicationDbContext _context;

        // Constructor for dependency injection.
        // The DbContext is injected by the ASP.NET Core DI container.
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        // This action retrieves all books from the database.
        // It returns an ActionResult<IEnumerable<BookModel>> which allows for
        // automatic serialization to JSON and proper HTTP status codes.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            try
            {
                // Retrieve all books asynchronously from the database.
                // ToListAsync() ensures the query is executed and results are returned as a list.
                var books = await _context.Books.ToListAsync();

                // Return the list of books.
                // If successful, this will return HTTP 200 OK with the JSON data.
                return Ok(books);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes.
                // In a real application, you'd use a logging framework (e.g., Serilog, NLog).
                Console.WriteLine($"Error getting books: {ex.Message}");
                // Return a 500 Internal Server Error if an exception occurs.
                return StatusCode(500, "An error occurred while retrieving the book list.");
            }
        }

        // You could add other API methods here, e.g., GetBookById, PostBook, PutBook, DeleteBook.
        // For example, to get a single book by ID:
        /*
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound(); // Returns HTTP 404 Not Found
            }

            return Ok(book); // Returns HTTP 200 OK with the book data
        }
        */
    }
}
