using coinly;
using coinly.GraphQL.Query;
using coinly.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policyBuilder => policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<GetAccount>()
    .AddType<User>()
    .AddType<Account>();

// SQLite Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

 var app = builder.Build();

 app.UseCors("AllowSpecificOrigin");
 app.MapGraphQL("/");
 app.Run();
 
 
 