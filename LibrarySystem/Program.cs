

using Data.Repositories;
using Data;
using LibrarySystem.Data.Mapping;
using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()      // <-- Allows all domains and ports
            .AllowAnyMethod()      // GET, POST, PUT, DELETE, etc.
            .AllowAnyHeader();     // Any custom or standard headers
    });
});
// Register services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = null;
        options.JsonSerializerOptions.WriteIndented = true;
    });
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookCopyRepository, BookCopyRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var mappingProfileAssembly = typeof(MappingProfile).Assembly;
// Better approach - scans entire assembly
builder.Services.AddAutoMapper(assemblies: new[] { mappingProfileAssembly });
// ✅ Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library System API",
        Version = "v1",
        Description = "API documentation for the Library System project"
    });
});

// ✅ Add EF Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();
app.UseCors("AllowAll");
// ✅ Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library System API V1");
    c.RoutePrefix = "swagger"; // URL will be: https://localhost:<port>/swagger
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
