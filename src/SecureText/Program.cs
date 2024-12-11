using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
builder.Services.Configure<JsonSerializerOptions>(static options =>
{
	// Configure JSON options here
	options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	options.WriteIndented = true;
	options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
});
builder.Services.AddDbContext<PoserDbContext>(options =>
{
	// Register Sqlite database here
	options.UseSqlite(builder.Configuration.GetConnectionString(nameof(PoserDbContext)));
});
builder.Services.AddScoped<IPoserDbContext>(provider => provider.GetRequiredService<PoserDbContext>());

var app = builder.Build();
// Create the database here
using var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var dbContext = provider.GetRequiredService<IPoserDbContext>();
await dbContext.Database.EnsureCreatedAsync();

app.UseEndpointDefinitions();

app.MapGet("/", () => "Hello SecureText!");

await app.RunAsync();