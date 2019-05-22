using MantenedoresPerfilCliente.Domain.Interfaces;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Dtos
{
    public class ExclusionDeleteDto:IDto
    {
       
        public int Id { get; set; }

        public string Identity { get; set; }
    }
}
