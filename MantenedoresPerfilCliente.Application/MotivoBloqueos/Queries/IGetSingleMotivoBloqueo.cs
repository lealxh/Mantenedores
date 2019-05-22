using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries
{
    public interface IGetSingleMotivoBloqueos
    {
        MotivoBloqueoDto Execute(int id);
    }
}