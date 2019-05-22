
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Queries
{
    public interface IGetSinglePerfil
    {
        PerfilDto Execute(int id);
    }
}