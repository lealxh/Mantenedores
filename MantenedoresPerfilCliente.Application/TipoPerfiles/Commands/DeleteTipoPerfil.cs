using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public class DeleteTipoPerfil : IDeleteTipoPerfil
    {
        private readonly IUnityOfWork _context;
     
        public DeleteTipoPerfil(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(TipoPerfilDeleteDto dto)
        {
            var registro = _context.TiposPerfil.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("TipoPerfiles", dto.Id.ToString());

            _context.TiposPerfil.Remove(registro);
            _context.Save();
        }
    }
}
