using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public class DeleteMotivoBloqueo : IDeleteMotivoBloqueo
    {
        private readonly IUnityOfWork _context;
     
        public DeleteMotivoBloqueo(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(MotivoBloqueoDeleteDto dto)
        {
            var registro = _context.MotivosBloqueo.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("MotivoBloqueos", dto.Id.ToString());

            _context.MotivosBloqueo.Remove(registro);
            _context.Save();
        }
    }
}
