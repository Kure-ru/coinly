using coinly;
using coinly.GraphQL.Mutation;
using coinly.GraphQL.Resolvers;
using coinly.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    .AddQueryType<Query>()
    .AddType<TransactionType>()
    .AddType<DateTimeType>()
    .AddMutationType<TransactionMutation>();

 var app = builder.Build();

 app.UseCors("AllowSpecificOrigin");
 app.MapGraphQL("/");
 app.Run();
 
 
 