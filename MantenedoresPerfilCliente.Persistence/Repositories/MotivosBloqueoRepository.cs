using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class MotivosBloqueoRepository:Repository<MotivoBloqueo>,IMotivosBloqueoRepository
    {
        public MotivosBloqueoRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}