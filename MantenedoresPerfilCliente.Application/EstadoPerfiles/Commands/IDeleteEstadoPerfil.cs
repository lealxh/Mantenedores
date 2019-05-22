using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public interface IDeleteEstadoPerfil
    {
        void Execute(EstadoPerfilDeleteDto dto);
    }
}