using Turnos.Domain.Entities;
using Turnos.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Turnos.SharedKernel;
using Radzen;
using Turnos.SharedKernel.Interfaces.Repositories;
using Turnos.SharedKernel.Interfaces.Services;
using Turnos.Application.Services;
using Turnos.Infrastructure.Persistence.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>(); ;

ConfigureServices(builder.Services);
ConfigureRepositories(builder.Services);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IAppointmentService, AppointmentService>();
    services.AddTransient<IPacienteService, PacienteService>();
    services.AddTransient<IProfesionalService, Profesionalservice>();

    services.AddRadzenComponents();

    var culture = new CultureInfo("es-ES");
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;

    services.AddLocalization();

    services.AddDomainProfiles();
}

static void ConfigureRepositories(IServiceCollection services)
{
    services.AddTransient<IAppointmentRepository, AppointmentRepository>();
    services.AddTransient<IPacienteRepository, PacienteRepository>();
    services.AddTransient<IProfesionalRepository, ProfesionalRepository>();

}