Step-by-Step Guide: Creating your Books Web API Project
Follow these steps carefully in Visual Studio to create and run your Web API application.

1. Create a New ASP.NET Core Web API Project
Open Visual Studio.

Click on "Create a new project".

In the "Create a new project" window, search for "ASP.NET Core Web API" (for C#) and click Next.

Configure your new project:

Project name: BooksAPI (or BooksWebApi)

Location: Choose a suitable location on your disk (can be in the same solution as BooksMVC or a new one).

Solution name: BooksAPI (or your preferred solution name)

Click Next.

In the "Additional information" window:

Framework: Choose a recent .NET version (e.g., .NET 8.0 or .NET 7.0).

Authentication type: None (for this example).

Configure for HTTPS: Checked (recommended).

Enable Docker: Unchecked.

Use controllers (uncheck to use minimal APIs): Make sure this is checked.

Enable OpenAPI support: Checked (recommended for Swagger/Swashbuckle, which helps with API documentation and testing).

Click Create.

2. Install NuGet Packages
Similar to the MVC project, you need to install Entity Framework Core and MySQL packages.

In Solution Explorer, right-click on your new BooksAPI project.

Select "Manage NuGet Packages...".

Go to the "Browse" tab.

Search for and install the following packages:

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools

Pomelo.EntityFrameworkCore.MySql (The MySQL provider for EF Core)

3. Configure MySQL Database Connection String
You will use the same connection string as your MVC application to connect to the existing BooksDB database.

In Solution Explorer, open the appsettings.json file in your BooksAPI project.

Add your MySQL connection string under ConnectionStrings. Ensure it matches the one used in your BooksMVC project, especially the password.

(The content for appsettings.json will be provided in a separate code immersive.)

4. Reuse BookModel and ApplicationDbContext
Instead of recreating these, you can copy them from your BooksMVC project or reference the BooksMVC project if they are in the same solution. For simplicity in this guide, we'll assume you're copying them over.

Copy BookModel.cs:

From your BooksMVC project, navigate to the Models folder.

Copy BookModel.cs.

In your BooksAPI project, create a new folder named Models (if it doesn't exist).

Paste BookModel.cs into the Models folder.

Important: Update the namespace in BookModel.cs to BooksAPI.Models.

Copy ApplicationDbContext.cs:

From your BooksMVC project, navigate to the Data folder (or wherever you placed it).

Copy ApplicationDbContext.cs.

In your BooksAPI project, create a new folder named Data (if it doesn't exist).

Paste ApplicationDbContext.cs into the Data folder.

Important: Update the namespace in ApplicationDbContext.cs to BooksAPI.Data. Also, ensure the using BooksAPI.Models; statement is correct.

(The content for these files will be re-provided for completeness in separate code immersives, but they should be identical to your previous ones except for the namespace.)

5. Configure Program.cs for Web API
You need to register the ApplicationDbContext and configure API-specific services.

In Solution Explorer, open the Program.cs file in your BooksAPI project.

Add the necessary using statements and the AddDbContext configuration. The Web API template already includes AddControllers() and Swagger configuration.

(The updated content for Program.cs will be provided in a separate code immersive.)

6. Create the BooksController (API Controller)
This controller will expose the endpoint to get the list of all books.

In Solution Explorer, right-click on the Controllers folder in your BooksAPI project.

Select "Add" > "Controller...".

Choose "API Controller - Empty" and click Add.

Name the controller BooksController.cs and click Add. (Note: We use BooksController because it's common practice for API controllers to be plural and end with Controller).

(The content for BooksController.cs will be provided in a separate code immersive.)

7. Run the Web API Application
Press F5 or click the "IIS Express" (or whatever server is configured) button in the Visual Studio toolbar to run your application.

Your browser should open to the Swagger UI (if enabled).

You will see the GET /api/Books endpoint listed.

Click on it, then click "Try it out", and then "Execute". You should see a JSON response with your book data.

8. Test with Postman or SOAPUI
To test the API directly:

Get the API URL: When you run the application, note the base URL (e.g., https://localhost:7001). The full endpoint for getting books will be https://localhost:7001/api/Books.

Using Postman:

Open Postman.

Select GET as the HTTP method.

Enter the API URL: https://localhost:7001/api/Books (replace the port if yours is different).

Click Send.

You should receive a JSON response containing your book list.

Using SOAPUI:

Open SOAPUI.

Create a new REST Project.

Enter the API URL: https://localhost:7001/api/Books.

It will create a Request 1. Double-click it.

Ensure the method is GET.

Click the green "Play" button (Submit Request).

You should see the JSON response in the response panel.

Now, let's provide the code for each file.
