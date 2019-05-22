using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class CargosRepository:Repository<Cargo>,ICargosRepository
    {
        public CargosRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}