using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using WebHooks.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddSwaggerGen();*/
builder.Services.AddLogging();

//builder.Services.AddTransient<IStripeEventsService>(x => new StripeEventsService());

var app = builder.Build();

var isIT = app.Environment.IsProduction();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseHsts();
}
else if (app.Environment.IsProduction())
{
    builder.Configuration.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
}

app.UseHttpsRedirection();

//app.MapPost("/webhook", async context =>
app.MapPost("/TicketManagerService", async context =>
{
    using var reader = new StreamReader(context.Request.Body);
    var json = await reader.ReadToEndAsync();
    var headers = PublicCode.GetHeaders(context);
    var deskEventType = PublicCode.GetDeskTypeEvent(headers);
    var objectResult = await PublicCode.RedirectToDeserialize(deskEventType, json);
    PublicCode.PrintResults(objectResult,context);
});

//Logging WIP
//app.MapGet("/errorlog", async context =>
//{
//    var controller = new ErrorLogController(logger);
//    var result = controller.GetErrorLog();
//    await context.Response.WriteAsync(result.ToString());
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
