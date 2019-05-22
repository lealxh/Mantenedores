using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.Universos.Dtos
{
    public class UniversoDeleteDto:IDto
    {
        
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
