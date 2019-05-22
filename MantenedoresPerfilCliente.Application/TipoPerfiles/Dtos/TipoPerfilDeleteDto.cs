using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos
{
    public class TipoPerfilDeleteDto:IDto
    {
        
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
