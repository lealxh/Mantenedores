using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Persistence.Repositories;
using System;

namespace MantenedoresPerfilCliente.Persistence.Shared
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly IDatabaseContext _database;

        public IAreasRepository Areas { get; set; }
         
        public ICargosRepository Cargos { get; set; }
        
        public IEstadoFiltroRepository EstadoFiltros { get; set; }
        
        public IEstadoPerfilRepository EstadoPerfiles { get; set; }
        
        public IExclusionesRepository Exclusiones { get; set; }

        public IFiltrosRepository Filtros { get; set; }

        public IMotivosBloqueoRepository MotivosBloqueo { get; set; }

        public IPerfilesRepository Perfiles { get; set; }

        public ITipoPerfilRepository TiposPerfil { get; set; }

        public IUniversoRepository Universos { get; set; }

        public UnityOfWork(DatabaseContext database)
        {
            _database = database;
            Areas=new AreasRepository(_database);
            Cargos=new CargosRepository(_database);
            EstadoFiltros=new EstadoFiltroRepository(_database);
            EstadoPerfiles=new EstadoPerfilRepository(_database);
            Exclusiones=new ExclusionesRepository(_database);
            Filtros=new FiltrosRepository(_database);
            MotivosBloqueo=new MotivosBloqueoRepository(_database);
            Perfiles = new PerfilesRepository(_database);
            TiposPerfil = new TipoPerfilRepository(_database);
            Universos = new UniversoRepository(_database);
            


        }

        public void Save()
        {
            _database.Save();
        }


        public void Dispose()
        {
            _database.Dispose();
            GC.SuppressFinalize(this);
        }

  
    }
}