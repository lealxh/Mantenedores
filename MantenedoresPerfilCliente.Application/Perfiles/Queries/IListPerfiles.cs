using System.Collections.Generic;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Queries
{
    public interface IListPerfiles
    {
        IEnumerable<PerfilDto> Execute();
    }
}