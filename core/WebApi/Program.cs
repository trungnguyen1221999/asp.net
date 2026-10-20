using WebApi;

var builder = WebApplication.CreateBuilder(args);
var appName = builder.Configuration.GetValue<string>("OrderSystem:AppName") ?? "WebApi";

var maxItem = builder.Configuration.GetValue<int>("OrderSystem:MaxOrderItemsPerOrder", 50);
Console.WriteLine($"Khoi dong {appName}, gioi han {maxItem} san pham/don hang.");

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

app.UseAuthorization();

app.UseRequestLogging();

app.MapControllers();

app.Run(async context =>
{
    await context.Response.WriteAsync("api is live");
});

app.Run();