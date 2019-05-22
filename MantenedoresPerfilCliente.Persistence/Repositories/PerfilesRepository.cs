using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{


    public class PerfilesRepository:Repository<Perfil>,IPerfilesRepository
    {

        public PerfilesRepository(IDatabaseContext database) : base(database)
        {

        }


        public IEnumerable<Perfil> GetPerfiles()
        {
            return _database.Perfiles.Include(x => x.EstadoPerfil).Include(y=>y.TipoPerfil).OrderBy(x=>x.Codigo).AsEnumerable();
        }

        public Perfil GetPerfil(int id)
        {
            return _database.Perfiles.Include(x => x.EstadoPerfil).Include(y=>y.TipoPerfil).SingleOrDefault(x=>x.Id==id);
        }
    }
}