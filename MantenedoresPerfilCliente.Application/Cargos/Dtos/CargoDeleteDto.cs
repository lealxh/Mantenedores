using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.Cargos.Dtos
{
    public class CargoDeleteDto:IDto
    {
        
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
