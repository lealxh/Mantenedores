using MantenedoresPerfilCliente.Application.Cargos.Dtos;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public interface IDeleteCargo
    {
        void Execute(CargoDeleteDto dto);
    }
}