using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public interface IDeleteEstadoFiltro
    {
        void Execute(EstadoFiltroDeleteDto dto);
    }
}