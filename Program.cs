using Microsoft.EntityFrameworkCore;
using veterinaria.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------
// 1️⃣ Cadena de conexión (usa tu nombre real de BD)
// ---------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("conexion");

// ---------------------------------------------------
// 2️⃣ Registrar el DbContext con MySQL
// ---------------------------------------------------
builder.Services.AddDbContext<veterinariaContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)))
);

// ---------------------------------------------------
// 3️⃣ Agregar Soporte a MVC
// ---------------------------------------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ---------------------------------------------------
// 4️⃣ Configuración del pipeline HTTP
// ---------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ---------------------------------------------------
// 5️⃣ Ruta por defecto (Mascotas/Index)
// ---------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mascotas}/{action=Index}/{id?}");

app.Run();
