using Microsoft.EntityFrameworkCore;
using CursoMaster_Proyecto_1.Models;
namespace CursoMaster_Proyecto_1.Datos
{
    //paso 2 Crear el la clase del Contexto

    public class ApplicationDBContext : DbContext
    {
        //paso 3 Crear contructor con parametro del tipo DBContextOptions que hereda de Options
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {


        }
        //paso 4 Agregar Modelos aqui
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
