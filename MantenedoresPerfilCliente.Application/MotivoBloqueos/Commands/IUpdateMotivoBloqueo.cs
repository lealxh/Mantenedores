using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public interface IUpdateMotivoBloqueo
    {
        void Execute(MotivoBloqueoUpdateDto dto);
    }
}