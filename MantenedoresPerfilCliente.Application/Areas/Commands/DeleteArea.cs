using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public class DeleteArea : IDeleteArea
    {
        private readonly IUnityOfWork _context;
     
        public DeleteArea(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(AreaDeleteDto dto)
        {
            var registro = _context.Areas.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Area", dto.Id.ToString());

            _context.Areas.Remove(registro);
            _context.Save();
        }
    }
}
