using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public class DeleteCargo : IDeleteCargo
    {
        private readonly IUnityOfWork _context;
     
        public DeleteCargo(IUnityOfWork context)
        {
            _context = context;
          
        }

        public void Execute(CargoDeleteDto dto)
        {
            var registro = _context.Cargos.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Cargo", dto.Id.ToString());

            _context.Cargos.Remove(registro);
            _context.Save();
        }
    }
}
