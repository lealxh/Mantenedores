using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public interface IDeletePerfil
    {
        void Execute(PerfilDeleteDto Dto);
    }
}