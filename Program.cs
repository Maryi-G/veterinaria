using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using veterinaria.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔗 Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("conexion");

// 🗄️ DbContext
builder.Services.AddDbContext<veterinariaContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)))
);

// 🔐 IDENTITY (ESTO ES LO QUE FALTABA)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<veterinariaContext>()
    .AddDefaultTokenProviders();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔐 AUTENTICACIÓN Y AUTORIZACIÓN (ORDEN IMPORTANTE)
app.UseAuthentication();
app.UseAuthorization();

// 👉 Página inicial = Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
