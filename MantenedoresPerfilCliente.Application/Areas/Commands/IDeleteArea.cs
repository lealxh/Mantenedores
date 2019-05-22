using MantenedoresPerfilCliente.Application.Areas.Dtos;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public interface IDeleteArea
    {
        void Execute(AreaDeleteDto dto);
    }
}