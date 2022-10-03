using TicketManagementAPI.Interfaces;
using TicketManagementAPI.Models.TeamHoodModels.Board;
using TicketManagementAPI.TeamworkModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<ITicketService,TicketList>();
builder.Services.AddTransient<IBoardItemService,BoardItem>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
