using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public class DeletePerfil : IDeletePerfil
    {
        private readonly IUnityOfWork _context;
        public DeletePerfil(IUnityOfWork context)
        {
            _context = context;
        }

        public void Execute(PerfilDeleteDto dto)
        {
            var registro = _context.Perfiles.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Perfil", dto.Id.ToString());

            _context.Perfiles.Remove(registro);
            _context.Save();
        }
    }
}
