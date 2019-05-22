using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public interface IInsertUniverso
    {
        void Execute(UniversoInsertDto dto);
    }
}