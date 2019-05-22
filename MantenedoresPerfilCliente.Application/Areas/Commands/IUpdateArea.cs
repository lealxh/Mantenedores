using MantenedoresPerfilCliente.Application.Areas.Dtos;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public interface IUpdateArea
    {
        void Execute(AreaUpdateDto dto);
    }
}