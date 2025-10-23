using QuotingApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IQuoteService, QuoteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Serve Angular static files
app.UseDefaultFiles();   // looks for index.html
app.UseStaticFiles();    // serves JS/CSS files

// Swagger only in dev at /swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger"; // Swagger at /swagger
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();

// API endpoints
app.MapControllers();

// Fallback: serve Angular index.html for any unknown route
app.MapFallbackToFile("index.html");

app.Run();
