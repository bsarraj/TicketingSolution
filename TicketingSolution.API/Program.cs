using Microsoft.Data.Sqlite;
using TicketingSolution.Persistence;
using Microsoft.EntityFrameworkCore;
using TicketingSolution.Core.Handler;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connString = "DataSource=:memory:";
var conn = new SqliteConnection(connString);
conn.Open();

builder.Services.AddDbContext<TicketingSolutionDbContext>(opt => opt.UseSqlite(conn));

builder.Services.AddScoped<ITicketBookingRequestHandler, TicketBookingRequestHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
