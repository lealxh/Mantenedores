using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Persistence.Repositories
{
    public class ExclusionesRepository:Repository<Exclusion>,IExclusionesRepository
    {
        public ExclusionesRepository(IDatabaseContext database) : base(database)
        {

        }

        public Exclusion GetExclusion(int id)
        {
            
            return _database.Exclusiones.
                Include(x=>x.Area).
                Include(x=>x.Cargo).
                Include(x=>x.MotivoBloqueo).SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Exclusion> GetExclusiones()
        {
         
       
            return _database.Exclusiones.
                Include(x=>x.Area).
                Include(x=>x.Cargo).
                Include(x=>x.MotivoBloqueo).AsEnumerable();

               
        }
        
    }
}