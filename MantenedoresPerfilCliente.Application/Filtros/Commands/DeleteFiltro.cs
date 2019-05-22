using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public class DeleteFiltro : IDeleteFiltro
    {
        private readonly IUnityOfWork _context;
        public DeleteFiltro(IUnityOfWork context)
        {
            _context = context;
        }

        public void Execute(FiltroDeleteDto dto)
        {
            var registro = _context.Filtros.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Filtro", dto.Id.ToString());

            _context.Filtros.Remove(registro);
            _context.Save();
        }
    }
}
