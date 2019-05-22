using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public interface IDeleteMotivoBloqueo
    {
        void Execute(MotivoBloqueoDeleteDto dto);
        
    }
}