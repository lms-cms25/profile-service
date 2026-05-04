var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddControllers();

// koppla DB + repository
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// middleware
app.UseHttpsRedirection();

app.MapControllers();

app.Run();