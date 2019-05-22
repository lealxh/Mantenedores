using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Queries
{
    public interface IGetSingleExclusion
    {
        ExclusionDto Execute(int id);
    }
}