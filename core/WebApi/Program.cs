using WebApi;
var builder = WebApplication.CreateBuilder(args);

var pageSize = builder.Configuration.GetValue<int>("OrderSystem:DefaultPageSize", 10);
Console.WriteLine($"Default page size: {pageSize}");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<OrderSystemOptions>(
    builder.Configuration.GetSection(OrderSystemOptions.SectionName)
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRequestLogging();

app.UseAdminHeaderCheck();

app.UseAuthorization();

app.MapControllers();

app.Run(async context =>
{
    await context.Response.WriteAsync("This is api ");
});

app.Run();