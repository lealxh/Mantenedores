using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos
{
    public class EstadoPerfilDeleteDto:IDto
    {
        
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
