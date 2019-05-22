using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public interface IInsertEstadoPerfil
    {
        void Execute(EstadoPerfilInsertDto dto);
    }
}