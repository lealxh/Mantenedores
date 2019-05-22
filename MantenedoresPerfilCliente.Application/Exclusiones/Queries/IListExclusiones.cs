using System.Collections.Generic;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Queries
{
    public interface IListExclusiones
    {
        IEnumerable<ExclusionDto> Execute();
    }
}