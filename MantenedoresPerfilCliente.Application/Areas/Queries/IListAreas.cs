using MantenedoresPerfilCliente.Application.Areas.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.Areas.Queries
{
    public interface IListAreas
    {
        IEnumerable<AreaDto> Execute();
    }
}