using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public interface IInsertEstadoFiltro
    {
        void Execute(EstadoFiltroInsertDto dto);
    }
}