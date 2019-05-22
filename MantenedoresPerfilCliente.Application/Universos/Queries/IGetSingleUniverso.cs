using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Queries
{
    public interface IGetSingleUniversos
    {
        UniversoDto Execute(int id);
    }
}