using MantenedoresPerfilCliente.Application.Filtros.Dtos;

namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public interface IGetSingleFiltro
    {
        FiltroDto Execute(int Id);
    }
}