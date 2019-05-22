using MantenedoresPerfilCliente.Application.Areas.Dtos;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public interface IInsertArea
    {
        void Execute(AreaInsertDto dto);
    }
}