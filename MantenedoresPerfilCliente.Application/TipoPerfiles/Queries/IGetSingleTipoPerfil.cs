using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Queries
{
    public interface IGetSingleTipoPerfiles
    {
        TipoPerfilDto Execute(int id);
    }
}