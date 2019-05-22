
using MantenedoresPerfilCliente.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MantenedoresPerfilCliente.Domain.Entities
{
    [Table("TBL_PRF_MNT_EXC")]
    public class Exclusion: IEntity
    {
        public int Id { get; set; }
        
        [Required,MaxLength(100)]
        public string Rut { get; set; }

       
        public Area Area { get; set; }
       
        [Display(Name = "Area")]
        public int AreaId { get; set; }
       
       
        public Cargo Cargo { get; set; }
        
        [Display(Name = "Cargo")]
        public int CargoId { get; set; }

        public MotivoBloqueo MotivoBloqueo { get; set; }
        
        [Display(Name = "Motivo de Bloqueo")]
        public int MotivoBloqueoId { get; set; }

        [Required,MaxLength(255)]
        public string Comentario { get; set; }
        
        [Required]
        public DateTime Fechainicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        
    }

}
