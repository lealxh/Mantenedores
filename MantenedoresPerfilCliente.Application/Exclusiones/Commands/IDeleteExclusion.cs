using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public interface IDeleteExclusion
    {
        void Execute(ExclusionDeleteDto dto);
    }
}