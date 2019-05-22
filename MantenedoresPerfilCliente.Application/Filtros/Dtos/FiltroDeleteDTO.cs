using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.Filtros.Dtos
{
    public class FiltroDeleteDto:IDto
    {
        public int Id { get; set; }
       
        public string Identity { get; set; }
    }
}
