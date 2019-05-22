using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos
{
    public class MotivoBloqueoUpdateDto:IDto
    {
        
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        [Required,MaxLength(100)]
        public string TipoBloqueo { get; set; }

        public string Identity { get; set; }
    }
}
