using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public interface IInsertMotivoBloqueo
    {
        void Execute(MotivoBloqueoInsertDto dto);
    }
}