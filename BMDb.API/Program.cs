using BMDb.API;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("/Logs/BMDb_Log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Services.AddCors();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AuthenticationAndAuthorization(builder.Configuration);
builder.Services.AddSwagger(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();