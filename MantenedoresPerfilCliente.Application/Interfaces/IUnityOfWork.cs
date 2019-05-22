namespace MantenedoresPerfilCliente.Application.Interfaces
{
    public interface IUnityOfWork
    {
         IAreasRepository Areas { get; set; }

         ICargosRepository Cargos { get; set; }
        
         IEstadoFiltroRepository EstadoFiltros { get; set; }
        
         IEstadoPerfilRepository EstadoPerfiles { get; set; }
        
         IExclusionesRepository Exclusiones { get; set; }

         IFiltrosRepository Filtros { get; set; }

         IMotivosBloqueoRepository MotivosBloqueo { get; set; }

         IPerfilesRepository Perfiles { get; set; }

         ITipoPerfilRepository TiposPerfil { get; set; }

         IUniversoRepository Universos { get; set; }

        void Save();
    }
}