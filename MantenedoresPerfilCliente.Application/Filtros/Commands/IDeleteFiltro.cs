using MantenedoresPerfilCliente.Application.Filtros.Dtos;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public interface IDeleteFiltro
    {
        void Execute(FiltroDeleteDto dto);
    }
}