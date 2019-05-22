using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public interface IInsertPerfil
    {
        void Execute(ref PerfilInserDto dto);
    }
}