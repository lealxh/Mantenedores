using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Perfiles.Dtos
{
    public class PerfilUpdateDto:IDto
    {
        
        public int Id { get; set; }
        
        [Required, Display(Name = "Codigo")]
        public int Codigo { get; set; }

        [Required,MaxLength(3),RegularExpression(@"^[R]\d{1,3}$",ErrorMessage = "La descripcion debe empezar por R seguido de numerico ej: R01"), Display(Name = "Desc. Perfil")]
        public string Descripcion { get; set; }

        [Display(Name = "PI Max")]
        public double? PiMax { get; set; }

        //[Display(Name = "Estado Perfil")]
        //public EstadoPerfil EstadoPerfil { get; set; }
        
        [Display(Name = "Estado Perfil")]
        public int EstadoPerfilId { get; set; }
        
        //[Display(Name = "Tipo Perfil")]
        //public TipoPerfil TipoPerfil { get; set; } 
       
        [Display(Name = "Tipo Perfil")]
        public int TipoPerfilId { get; set; }

        public string Identity { get; set; }
    }
}
