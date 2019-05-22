using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public class DeleteEstadoPerfil : IDeleteEstadoPerfil
    {
        private readonly IUnityOfWork _context;
     
        public DeleteEstadoPerfil(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(EstadoPerfilDeleteDto dto)
        {
            var registro = _context.EstadoPerfiles.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("EstadoPerfiles", dto.Id.ToString());

            _context.EstadoPerfiles.Remove(registro);
            _context.Save();
        }
    }
}
