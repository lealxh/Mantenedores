using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.Application.Interfaces
{
    public interface IPerfilesRepository: IRepository<Perfil>
    {
        IEnumerable<Perfil> GetPerfiles();
        
        Perfil GetPerfil(int id);
    }
}
