using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos
{
    public class EstadoFiltroDto:IDto
    {
        
        public int Id { get; set; }

        [Required,MaxLength(1)]
        public string Cod { get; set; }

        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        public string Identity { get; set; }
    }
}
