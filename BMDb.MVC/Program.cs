using BMDb.MVC.CustomService;
using BMDb.MVC.Data;
using BMDb.MVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IAsyncJwtService, JwtService>();
builder.Services.AddScoped<IAsyncMovieService, MovieService>();
builder.Services.AddScoped<IAsyncEditorService, EditorService>();


var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.WithProcessName()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .WriteTo.Console(outputTemplate: "{Timestamp: yyyy / MM / dd   HH:mm:ss} {Level:w3} " +
                                     "{Message: lj} " +
                                     "{NewLine}" +
                                     "ThreadId: {ThreadId} {NewLine}" +
                                     "ThreadName: {ThreadName}{NewLine}" +
                                     "ProcessName: {ProcessName}" +
                                     "{Exception}" +
                                     "{NewLine}")
    .CreateLogger();

builder.Logging.AddSerilog(logger);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

await app.RunAsync();