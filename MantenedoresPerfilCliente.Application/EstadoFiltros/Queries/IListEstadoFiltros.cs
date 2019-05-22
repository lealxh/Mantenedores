using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Queries
{
    public interface IListEstadoFiltros
    {
        IEnumerable<EstadoFiltroDto> Execute();
    }
}