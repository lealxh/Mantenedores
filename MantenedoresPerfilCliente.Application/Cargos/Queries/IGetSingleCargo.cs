using MantenedoresPerfilCliente.Application.Cargos.Dtos;

namespace MantenedoresPerfilCliente.Application.Cargos.Queries
{
    public interface IGetSingleCargo
    {
        CargoDto Execute(int id);
    }
}