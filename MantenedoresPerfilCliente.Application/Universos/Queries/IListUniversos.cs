using MantenedoresPerfilCliente.Application.Universos.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.Universos.Queries
{
    public interface IListUniversos
    {
        IEnumerable<UniversoDto> Execute();
    }
}