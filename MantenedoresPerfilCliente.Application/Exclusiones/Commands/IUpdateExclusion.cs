using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public interface IUpdateExclusion
    {
        void Execute(ExclusionUpdateDto dto);
    }
}