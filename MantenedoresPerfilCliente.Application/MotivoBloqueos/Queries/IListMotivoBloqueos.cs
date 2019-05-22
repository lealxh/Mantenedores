using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries
{
    public interface IListMotivoBloqueos
    {
        IEnumerable<MotivoBloqueoDto> Execute();
    }
}