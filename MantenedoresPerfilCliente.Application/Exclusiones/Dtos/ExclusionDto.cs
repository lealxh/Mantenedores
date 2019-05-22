
using MantenedoresPerfilCliente.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Dtos
{
    public class ExclusionDto:IDto
    {
        
        public int Id { get; set; }
        
        [Required,MaxLength(100)]
        public string Rut { get; set; }

       
       // public Area Area { get; set; }
       
        public int AreaId { get; set; }

        public String AreaNombre { get; set; }
       
       
        //public Cargo Cargo { get; set; }
        
        public int CargoId { get; set; }

        public String CargoNombre { get; set; }


        public int MotivoBloqueoId { get; set; }

        public string MotivoBloqueoDescripcion { get; set; }

         public string TipoBloqueo { get; set; }

        [Required,MaxLength(255)]
        public string Comentario { get; set; }
        
        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public string Identity { get; set; }
    }
}
