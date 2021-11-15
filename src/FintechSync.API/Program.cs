using FintechSync.API;
using FintechSync.API.Data;
using FintechSync.API.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (seed)
{
    SeedData.EnsureSeedData(builder.Configuration.GetConnectionString("FintechSync"));
    return;
}

builder.Services.AddDbContext<FintechSyncContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("FintechSync"), o => o.MigrationsAssembly(typeof(Program).Assembly.FullName)));

builder.Services.AddControllersWithViews();

builder.Services.AddBff();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie";
    options.DefaultChallengeScheme = "oidc";
    options.DefaultSignOutScheme = "oidc";
})
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://demo.duendesoftware.com";

    // confidential client using code flow + PKCE
    options.ClientId = "spa";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    // query response type is compatible with strict SameSite mode
    options.ResponseMode = "query";

    // get claims without mappings
    options.MapInboundClaims = false;
    options.GetClaimsFromUserInfoEndpoint = true;

    // save tokens into authentication session
    // to enable automatic token management
    options.SaveTokens = true;

    // request scopes
    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("api1");

    // and refresh token
    options.Scope.Add("offline_access");

    options.TokenValidationParameters = new()
    {
        NameClaimType = "name",
        RoleClaimType = "role"
    };
})
.AddCookie("cookie", options =>
{
    // set session lifetime
    options.ExpireTimeSpan = TimeSpan.FromHours(8);

    // sliding or absolute
    options.SlidingExpiration = false;

    // host prefixed cookie name
    options.Cookie.Name = "__Host-spa";

    // strict SameSite handling
    options.Cookie.SameSite = SameSiteMode.Strict;
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<FintechSyncContext>()
    .AddDefaultTokenProviders();


// UI stuff
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // see https://docs.duendesoftware.com/identityserver/v5/fundamentals/resources/
    options.EmitStaticAudienceClaim = true;
})
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryClients(Config.Clients)
.AddAspNetIdentity<ApplicationUser>();

builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseBff();

app.UseHttpsRedirection();

app.UseCors("default");

app.UseIdentityServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBffManagementEndpoints();
    endpoints.MapDefaultControllerRoute();
});


app.Run();
