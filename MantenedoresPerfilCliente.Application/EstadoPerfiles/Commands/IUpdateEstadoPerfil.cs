using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public interface IUpdateEstadoPerfil
    {
        void Execute(EstadoPerfilUpdateDto dto);
    }
}