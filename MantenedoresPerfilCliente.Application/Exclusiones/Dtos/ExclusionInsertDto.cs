using MantenedoresPerfilCliente.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Dtos
{
    public class ExclusionInsertDto:IDto
    {
        
        public int Id { get; set; }
        
        [Required,MaxLength(100)]
        public string Rut { get; set; }

       
        // public Area Area { get; set; }
       
        public int AreaId { get; set; }
       
       
        //public Cargo Cargo { get; set; }
        
        public int CargoId { get; set; }

        //public MotivoBloqueo MotivoBloqueo { get; set; }

        public int MotivoBloqueoId { get; set; }

        [Required,MaxLength(255)]
        public string Comentario { get; set; }
        
        [Required]
        public DateTime Fechainicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public string Identity { get; set; }
    }
}
