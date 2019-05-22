using MantenedoresPerfilCliente.Domain.Entities;
using MantenedoresPerfilCliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MantenedoresPerfilCliente.Persistence.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<EstadoFiltro> EstadosFiltro { get; set; }
        public DbSet<EstadoPerfil> EstadosPerfil { get; set; }
        public DbSet<Exclusion> Exclusiones { get; set; }
        public DbSet<Filtro> Filtros { get; set; }
        public DbSet<MotivoBloqueo> MotivosBloqueo { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<TipoPerfil> TiposPerfil { get; set; }
        public DbSet<Universo> Universos { get; set; }


        public DatabaseContext()
        {
                
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {  
            builder.Entity<Filtro>()
                .HasIndex(u => u.Orden)
                .IsUnique();
            //builder.Entity<TipoPerfil>().HasData(
            //    new TipoPerfil(){Id = 1,Cod = "F",Descripcion = "Filtro"},
            //    new TipoPerfil(){Id = 2,Cod = "F",Descripcion = "Filtro"});

            //builder.Entity<EstadoPerfil>().HasData(
            //    new EstadoPerfil(){Id = 1,Cod ="A",Descripcion = "Activo"},
            //    new EstadoPerfil(){Id = 2,Cod = "N",Descripcion = "Inactivo"});
           
            //builder.Entity<Universo>().HasData(
            //    new Universo(){Id = 1,Cod ="C",Descripcion = "Cliente"},
            //    new Universo(){Id = 2,Cod = "N",Descripcion = "No Cliente"},
            //    new Universo(){Id = 3,Cod = "A",Descripcion = "Ambos"});

            //builder.Entity<EstadoFiltro>().HasData(
            //    new EstadoFiltro(){Id = 1,Cod ="A",Descripcion = "Activo"},
            //    new EstadoFiltro(){Id = 2,Cod = "N",Descripcion = "Inactivo"});

            //builder.Entity<MotivoBloqueo>().HasData(
            //    new MotivoBloqueo(){Id =1,Descripcion = "Fraude(Titular-Relacionado)",TipoBloqueo = "Permanente"},
            //    new MotivoBloqueo(){Id =2,Descripcion = "Suficientemente atendido",TipoBloqueo = "Temporal"},
            //    new MotivoBloqueo(){Id =3,Descripcion = "Sector Economico",TipoBloqueo = "Temporal"},
            //    new MotivoBloqueo(){Id =4,Descripcion = "Cliente no desea recibir Ofertas",TipoBloqueo = "Temporal"},
            //    new MotivoBloqueo(){Id =5,Descripcion = "Bloqueo Duro de Riesgo",TipoBloqueo = "Permanente"},
            //    new MotivoBloqueo(){Id =6,Descripcion = "Bloqueo Comercial",TipoBloqueo = "Permanente"},
            //    new MotivoBloqueo(){Id =7,Descripcion = "Bloqueo 1",TipoBloqueo = "Temporal"},
            //    new MotivoBloqueo(){Id =8,Descripcion = "Bloqueo 2",TipoBloqueo = "Temporal"},
            //    new MotivoBloqueo(){Id =9,Descripcion = "Bloqueo 3",TipoBloqueo = "Temporal"});

            //builder.Entity<Area>().HasData(
            //    new Area(){Id =1,Nombre = "Admision Riesgo"},
            //    new Area(){Id =2,Nombre = "Desarrollo Comercial"});

            
            //builder.Entity<Cargo>().HasData(
            //    new Cargo(){Id =1,Descripcion = "Ejecutivo Comercial"},
            //    new Cargo(){Id =2,Descripcion = "Agente Comercial"},
            //    new Cargo(){Id =3,Descripcion = "Analista de Riesgo"},
            //    new Cargo(){Id =4,Descripcion = "Jefe Deto."},
            //    new Cargo(){Id =5,Descripcion = "Gerente de Riesgo"},
            //    new Cargo(){Id =6,Descripcion = "Otro"});




        }
  

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}