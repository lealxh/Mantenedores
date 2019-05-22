using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public interface IInsertExclusion
    {
        void Execute(ExclusionInsertDto dto);
    }
}