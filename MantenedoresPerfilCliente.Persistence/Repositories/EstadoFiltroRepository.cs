using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class EstadoFiltroRepository:Repository<EstadoFiltro>,IEstadoFiltroRepository
    {
        public EstadoFiltroRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}