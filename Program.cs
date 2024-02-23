using Fractal_API_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors();
app.UseHttpsRedirection();

app.MapGet("/get-fractal-image", int[] (HttpRequest request) =>
{
    int width = int.TryParse(request.Query["width"], out int w) ? w : 640;
    int height = int.TryParse(request.Query["height"], out int h) ? h : 480;

    int[] pixel_data = new int[width * height * 4];

    // Calling the C++/CUDA code
    FractalFabricator.get_pixel_data(pixel_data, width, height);

    return pixel_data;
});

app.Run();