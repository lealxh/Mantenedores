using System.Collections.Generic;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;

namespace MantenedoresPerfilCliente.Application.Cargos.Queries
{
    public interface IListCargos
    {
        IEnumerable<CargoDto> Execute();
    }
}