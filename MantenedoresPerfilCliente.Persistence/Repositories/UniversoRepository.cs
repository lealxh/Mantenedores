using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class UniversoRepository: Repository<Universo>,IUniversoRepository
    {
        public UniversoRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}