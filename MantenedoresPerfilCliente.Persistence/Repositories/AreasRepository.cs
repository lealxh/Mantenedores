using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class AreasRepository: Repository<Area>,IAreasRepository
    {
        public AreasRepository(IDatabaseContext database) : base(database)
        {
        }
    }

  
}
