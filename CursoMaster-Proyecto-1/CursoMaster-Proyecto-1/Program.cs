//Paso 5 Instalar los paquetes Nuggets para Trabajar son Sql e importar los
using CursoMaster_Proyecto_1.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Configuracion de la cadena de conexion
//paso 6 Crear la Cadena de conexion, ponerla en Appsettings y obtenerla
builder.Services.AddDbContext<ApplicationDBContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"))

);
//Paso 7 Hacer la migracion mediante la consola con el comando add-migration (El nombre de la migracion)
//Paso 8 mandarlo a la base de datos con el comando update-database

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
