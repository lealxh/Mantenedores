using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class EstadoPerfilRepository:Repository<EstadoPerfil>,IEstadoPerfilRepository
    {
        public EstadoPerfilRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
