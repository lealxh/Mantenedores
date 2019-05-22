using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public class DeleteExclusion : IDeleteExclusion
    {
        private readonly IUnityOfWork _context;
        public DeleteExclusion(IUnityOfWork context)
        {
            _context = context;
        }

        public void Execute(ExclusionDeleteDto dto)
        {
            var registro = _context.Exclusiones.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Exclusion", dto.Id.ToString());

            _context.Exclusiones.Remove(registro);
            _context.Save();
        }
    }
}
