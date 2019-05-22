using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public interface IDeleteUniverso
    {
        void Execute(UniversoDeleteDto dto);
        
    }
}