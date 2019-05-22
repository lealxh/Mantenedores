
using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MantenedoresPerfilCliente.Domain.Entities
{
    [Table("TBL_PRF_MNT_EPF")]
    public class EstadoPerfil: IEntity
    {
        public int Id { get; set; }

        [Required,MaxLength(1),Display(Name = "Estado")]
        public string Cod { get; set; }

        [Required,MaxLength(100),Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}