using System.Collections.Generic;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;

namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public interface IListFiltros
    {
        IEnumerable<FiltroDto> Execute();
    }
}