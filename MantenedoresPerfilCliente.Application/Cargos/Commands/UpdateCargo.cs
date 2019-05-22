using AutoMapper;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public class UpdateCargo : IUpdateCargo
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateCargo(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(CargoUpdateDto dto)
        {
            var cargo = _context.Cargos.SingleOrDefault(x => x.Id == dto.Id);

            if (cargo == null)
                throw new EntityNotFoundException("Cargo", dto.Id.ToString());

            _mapper.Map(dto, cargo);

            _context.Save();

        }

    }
}