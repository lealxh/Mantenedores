using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.Interfaces
{
    public interface IExclusionesRepository:IRepository<Exclusion>
    {
       IEnumerable<Exclusion> GetExclusiones();
       Exclusion GetExclusion(int id);
      
    }
}
