using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Universos.Dtos
{
    public class UniversoDto:IDto
    {
        
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        [Required,MaxLength(1)]
        public string Cod { get; set; }

        public string Identity { get; set; }
    }
}
