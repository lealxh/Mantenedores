using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Queries
{
    public interface IListTipoPerfiles
    {
        IEnumerable<TipoPerfilDto> Execute();
    }
}