using AutoMapper;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.Cargos.Queries
{
    public class ListCargos : IListCargos
    {

        private readonly ICargosRepository _context;
        private readonly IMapper _mapper;

        public ListCargos(ICargosRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<CargoDto> Execute()
        {  
            return _context.GetAll().Select( registro=> _mapper.Map<Cargo,CargoDto>(registro));
        }
    }
}
