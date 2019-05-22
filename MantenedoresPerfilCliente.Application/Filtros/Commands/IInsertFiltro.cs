using MantenedoresPerfilCliente.Application.Filtros.Dtos;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public interface IInsertFiltro
    {
        void Execute(FiltroInsertDto dto);
    }
}