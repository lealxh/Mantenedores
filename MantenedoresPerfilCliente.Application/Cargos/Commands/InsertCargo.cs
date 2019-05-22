using AutoMapper;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Cargos.Commands
{
    public class InsertCargo : IInsertCargo
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertCargo(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(CargoInsertDto dto)
        {
            var registro = _mapper.Map<CargoInsertDto, Cargo>(dto);
            _context.Cargos.Add(registro);
            _context.Save();
        }

    }
}