using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public interface IUpdateTipoPerfil
    {
        void Execute(TipoPerfilUpdateDto dto);
    }
}