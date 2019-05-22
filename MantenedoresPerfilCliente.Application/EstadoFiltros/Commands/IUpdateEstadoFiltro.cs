using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public interface IUpdateEstadoFiltro
    {
        void Execute(EstadoFiltroUpdateDto dto);
    }
}