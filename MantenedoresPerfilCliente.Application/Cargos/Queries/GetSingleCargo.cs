using AutoMapper;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Cargos.Queries
{
    public class GetSingleCargo : IGetSingleCargo
    {
        private readonly ICargosRepository _context;
        private readonly IMapper _mapper;

        public GetSingleCargo(ICargosRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public CargoDto Execute(int id)
        {
            var cargo = _context.Get(id);
            if(cargo==null)
                throw new EntityNotFoundException("Cargo",id.ToString());
            return _mapper.Map<Cargo,CargoDto>(cargo);
        }

        
    }
}