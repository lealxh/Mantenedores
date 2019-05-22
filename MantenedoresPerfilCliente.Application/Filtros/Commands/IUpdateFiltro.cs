using MantenedoresPerfilCliente.Application.Filtros.Dtos;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public interface IUpdateFiltro
    {
        void Execute(FiltroUpdateDto dto);
    }
}