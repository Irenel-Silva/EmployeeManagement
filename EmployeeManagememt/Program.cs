using EmployeeManagememt;
using EmployeeManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.(
//builder.Services.AddDbContextPool<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection"));
//});
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer("Server=MGV13N\\PRIMAVERA;Database=HRDB; Trusted_Connection=True;TrustServerCertificate=True;");
    });
builder.Services.AddRazorPages();
//builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>(); // Comunicação com SQL

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = true;
    options.ConstraintMap.Add("even", typeof(EvenConstraint));
});

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
