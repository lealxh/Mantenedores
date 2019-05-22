
using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MantenedoresPerfilCliente.Domain.Entities
{
    [Table("TBL_PRF_MNT_MVB")]
    public class MotivoBloqueo: IEntity
    {
        public int Id { get; set; }
       
        [Required,Display(Name = "Motivo Bloqueo"),MaxLength(100)]
        public string Descripcion { get; set; }
    
        [Required,Display(Name = "Tipo de Bloqueo"),MaxLength(100)]
        public string TipoBloqueo { get; set; }
    }
}
