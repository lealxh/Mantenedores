using MantenedoresPerfilCliente.Application.Areas.Dtos;

namespace MantenedoresPerfilCliente.Application.Areas.Queries
{
    public interface IGetSingleArea
    {
        AreaDto Execute(int id);
    }
}