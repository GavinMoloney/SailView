using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SailView.Areas.Identity;
using SailView.Data;
using SailView.Services;
using SailView.Services.Interfaces;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

//for X-Forward-For headers
/*builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
builder.Services.AddHttpContextAccessor();

//for anti-csrf
builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

//HSTS
builder.Services.Configure<HostFilteringOptions>(options =>
{
    options.AllowEmptyHosts = false;
});
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);

});

//cookie secure flag
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.Always;
});*/


// Add services to the container.
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var sailAppDbContextConnectionString = builder.Configuration.GetConnectionString("SailAppDbContextConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

builder.Services.AddDbContextFactory<SailAppDbContext>((_, options) =>
    options.UseSqlServer(sailAppDbContextConnectionString));




builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddGeolocationServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddTransient<BoatService>();
builder.Services.AddTransient<RaceService>();
builder.Services.AddTransient<ResultService>();
builder.Services.AddTransient<BoatResultService>();

builder.Services.AddHttpClient();
builder.Services.AddMudServices();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
builder.Services.AddSingleton<ExportService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ReverseGeocodingService>();
builder.Services.AddHttpClient<TideService>();
builder.Services.AddScoped<Darnton.Blazor.DeviceInterop.Geolocation.IGeolocationService, Darnton.Blazor.DeviceInterop.Geolocation.GeolocationService>();
//builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position));
//for adding user role authentication
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//.AddRoles<IdentityRole>();

// Add HTTPS enforcement and redirection
/*builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
    options.HttpsPort = 443;
});*/

var app = builder.Build();

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI1MDM4NEAzMjMwMmUzNDJlMzBiKzhEZkFORVdrSnE5Vm9oMUM3Qjh3cjVINm1kVzI2dFZ6dGl1dVNqVlJnPQ==");


//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();

//for csp header, still blocks styling
//app.Use(async (context, next) =>
//{
//    context.Response.Headers["Content-Security-Policy"] = "default-src 'self'; " +
//        "font-src 'self' data: https://fonts.gstatic.com https://fonts.googleapis.com; " +
//        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdnjs.cloudflare.com openweathermap.org; " +
//        "connect-src 'self' https: wss: https://api.openweathermap.org/data/; " +
//        "img-src 'self' blob: https://*.tile.openweathermap.org openweathermap.org; " +
//        "script-src 'self' 'unsafe-eval' 'unsafe-inline' openweathermap.org api.openweathermap.org";
//    await next();
//});

// low restriction csp header
/*app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] = "default-src * 'self' data: blob: 'unsafe-inline' 'unsafe-eval';";
    await next();
});*/


//anti-csrf
/*app.Use(async (context, next) =>
{
    if (string.Equals(context.Request.Path.Value, "/_blazor", StringComparison.OrdinalIgnoreCase) &&
        string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
    {
        var antiforgery = context.RequestServices.GetRequiredService<IAntiforgery>();
        await antiforgery.ValidateRequestAsync(context);
    }

    await next();
});*/

//remove server from header
/*app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("Server");
    await next();
});*/

//cookies
//app.UseCookiePolicy();

//no sniff
/*app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    await next();
});*/

app.MapFallbackToPage("/_Host");

app.Run();
