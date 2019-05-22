using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public interface IUpdateUniverso
    {
        void Execute(UniversoUpdateDto dto);
    }
}