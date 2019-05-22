using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MantenedoresPerfilCliente.Persistence.Shared
{
    public interface IDatabaseContext
    {
        DbSet<Area> Areas { get; set; }

        DbSet<Cargo> Cargos { get; set; }
        
        DbSet<EstadoFiltro> EstadosFiltro { get; set; }
        
        DbSet<Exclusion> Exclusiones { get; set; }

        DbSet<Filtro> Filtros { get; set; }

        DbSet<MotivoBloqueo> MotivosBloqueo { get; set; }

        DbSet<Perfil> Perfiles { get; set; }

        DbSet<TipoPerfil> TiposPerfil { get; set; }

        DbSet<Universo> Universos { get; set; }

        DbSet<T> Set<T>() where T : class, IEntity;

        void Save();

        void Dispose();

      

    }
}