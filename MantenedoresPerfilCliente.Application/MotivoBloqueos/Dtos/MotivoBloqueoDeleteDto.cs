using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos
{
    public class MotivoBloqueoDeleteDto:IDto
    {
        
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
