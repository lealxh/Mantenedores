using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MantenedoresPerfilCliente.Domain.Entities
{
    [Table("TBL_PRF_MNT_CRG")]
    public class Cargo: IEntity
    {
        public int Id { get; set; }
        [Required,MaxLength(100),Display(Name = "Cargo")]
        public string Descripcion { get; set; }
    }
}
