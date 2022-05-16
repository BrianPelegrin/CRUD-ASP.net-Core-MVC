using System.ComponentModel.DataAnnotations;

namespace CursoMaster_Proyecto_1.Models
{
    //Paso 1 Crear el/los Modelos del proyecto

    //2- ir a Datos e ir al contexto

    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es Obligatorio")]
        [Display(Name = "Telefono")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "El Campo Identificacion es Obligatorio")]
        [Display(Name = "Identificacion")]
        public string DocumentiId { get; set; }
        [Required(ErrorMessage = "El Campo Email es Obligatorio")]       
        public string Email { get; set; }


    }
}
