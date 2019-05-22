using MantenedoresPerfilCliente.Application.Cargos.Dtos;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public interface IUpdateCargo
    {
        void Execute(CargoUpdateDto dto);
    }
}