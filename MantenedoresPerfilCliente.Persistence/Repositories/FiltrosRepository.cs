using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class FiltrosRepository:Repository<Filtro>,IFiltrosRepository
    {
        public FiltrosRepository(IDatabaseContext database) : base(database)
        {
            
           
        }
        public Filtro GetFiltro(int id)
        {
            return _database.Filtros.
                Include(x => x.EstadoFiltro).
                Include(y => y.Perfil).
                Include(z => z.Universo).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Filtro> GetFiltros()
        {
            return _database.Filtros.
                Include(x => x.EstadoFiltro).
                Include(y=>y.Perfil).
                Include(z=>z.Universo).
                OrderBy(x=>x.Orden).AsEnumerable();
        }

  
    }
}