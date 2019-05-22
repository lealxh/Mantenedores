using MantenedoresPerfilCliente.Application.Cargos.Dtos;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public interface IInsertCargo
    {
        void Execute(CargoInsertDto dto);
    }
}