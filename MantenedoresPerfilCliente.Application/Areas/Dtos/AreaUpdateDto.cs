using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Areas.Dtos
{
    public class AreaUpdateDto:IDto
    {
        
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Nombre { get; set; }

        public string Identity { get; set; }
    }
}
