using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries
{
    public interface IGetSingleEstadoPerfiles
    {
        EstadoPerfilDto Execute(int id);
    }
}