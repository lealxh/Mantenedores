using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public class DeleteEstadoFiltro : IDeleteEstadoFiltro
    {
        private readonly IUnityOfWork _context;
     
        public DeleteEstadoFiltro(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(EstadoFiltroDeleteDto dto)
        {
            var registro = _context.EstadoFiltros.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("EstadoFiltro", dto.Id.ToString());

            _context.EstadoFiltros.Remove(registro);
            _context.Save();
        }
    }
}
