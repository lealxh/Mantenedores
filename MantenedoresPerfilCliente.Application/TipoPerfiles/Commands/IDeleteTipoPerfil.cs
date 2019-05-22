using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public interface IDeleteTipoPerfil
    {
        void Execute(TipoPerfilDeleteDto dto);
        
    }
}