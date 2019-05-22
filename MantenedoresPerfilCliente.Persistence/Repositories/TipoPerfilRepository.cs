using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class TipoPerfilRepository:Repository<TipoPerfil>,ITipoPerfilRepository
    {
        public TipoPerfilRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}