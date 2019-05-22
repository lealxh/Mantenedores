using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public interface IInsertTipoPerfil
    {
        void Execute(TipoPerfilInsertDto dto);
    }
}