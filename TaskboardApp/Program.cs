// Bootstraps the application and loads configuration, logging, and DI container.
var builder = WebApplication.CreateBuilder(args);

// Registers controller support so API endpoints can be invoked.
builder.Services.AddControllers();

// Enables API endpoint discovery (useful for tools even without Swagger).
builder.Services.AddEndpointsApiExplorer();

// Builds the middleware pipeline and final application object.
var app = builder.Build();

// Configure middleware for development diagnostics.
if (app.Environment.IsDevelopment())
{
    // Provides detailed error pages during development.
    app.UseDeveloperExceptionPage();
}

// Redirects all HTTP traffic to HTTPS for secure communication.
app.UseHttpsRedirection();

// Maps controller-based API routes to the request pipeline.
app.MapControllers();

// Starts the web application and begins listening for requests.
await app.RunAsync();
