using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Areas.Dtos
{
    public class AreaDto:IDto
    {
        
        public int Id { get; set; }
        [Required,RegularExpression(@"^[A-Za-z\s]+$")]
        public string Nombre { get; set; }

        public string Identity { get; set; }
    }
}
