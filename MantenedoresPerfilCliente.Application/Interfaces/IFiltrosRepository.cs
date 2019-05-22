
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
namespace MantenedoresPerfilCliente.Application.Interfaces
{
    public interface IFiltrosRepository:IRepository<Filtro>
    {
       IEnumerable<Filtro> GetFiltros();
       Filtro GetFiltro(int id);
      
    }
}
