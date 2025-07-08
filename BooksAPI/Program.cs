using Microsoft.EntityFrameworkCore;
using BooksAPI.Data; // Import your DbContext namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Adds controllers for handling API requests.
builder.Services.AddControllers();

// Configure DbContext with MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// IMPORTANT: These two lines are crucial for Swagger/OpenAPI generation
builder.Services.AddEndpointsApiExplorer(); // This service is required for Swagger to discover API endpoints
builder.Services.AddSwaggerGen(); // This service generates the OpenAPI specification (Swagger JSON)

var app = builder.Build();

// Configure the HTTP request pipeline.
// In development, use Swagger UI for API testing and documentation.
// IMPORTANT: These two lines are crucial for serving the Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // This middleware serves the generated Swagger JSON document
    app.UseSwaggerUI(); // This middleware serves the Swagger UI (HTML, CSS, JS) from the generated JSON
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.

app.UseAuthorization(); // Enables authorization middleware.

// Maps controller actions to routes.
app.MapControllers();

app.Run(); // Runs the application.
