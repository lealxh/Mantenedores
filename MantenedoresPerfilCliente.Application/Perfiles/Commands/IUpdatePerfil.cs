using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public interface IUpdatePerfil
    {
        void Execute(PerfilUpdateDto dto);
    }
}