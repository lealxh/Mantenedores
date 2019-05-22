using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries
{
    public interface IListEstadoPerfiles
    {
        IEnumerable<EstadoPerfilDto> Execute();
    }
}