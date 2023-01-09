using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarRentProj.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options => { options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin")); });
// Add services to the container.
builder.Services.AddRazorPages(options => { 
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AllowAnonymousToPage("/Cars/Index");
    options.Conventions.AllowAnonymousToPage("/Cars/Details");
    options.Conventions.AuthorizePage("/Colors/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Colors/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Cars/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Cars/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Models/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Models/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Rents/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Rents/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Makes/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Makes/Edit", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});
builder.Services.AddDbContext<CarRentProjContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentProjContext") ?? throw new InvalidOperationException("Connection string 'CarRentProjContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<LibraryIdentityContext>();


//---------------------------------
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentProjContext") ?? throw new InvalidOperationException("Connection string 'CarRentProjContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
