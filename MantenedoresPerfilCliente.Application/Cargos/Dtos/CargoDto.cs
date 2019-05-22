using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Cargos.Dtos
{
    public class CargoDto:IDto
    {
        
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Descripcion { get; set; }

        public string Identity { get; set; }
    }
}
