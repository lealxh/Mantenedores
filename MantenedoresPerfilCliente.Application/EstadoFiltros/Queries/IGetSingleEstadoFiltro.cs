using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Queries
{
    public interface IGetSingleEstadoFiltro
    {
        EstadoFiltroDto Execute(int id);
    }
}