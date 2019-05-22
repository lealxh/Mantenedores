using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public class DeleteUniverso : IDeleteUniverso
    {
        private readonly IUnityOfWork _context;
     
        public DeleteUniverso(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(UniversoDeleteDto dto)
        {
            var registro = _context.Universos.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Universos", dto.Id.ToString());

            _context.Universos.Remove(registro);
            _context.Save();
        }
    }
}
