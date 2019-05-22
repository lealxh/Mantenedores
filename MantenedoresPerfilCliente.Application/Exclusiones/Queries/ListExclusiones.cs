using AutoMapper;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Queries
{
    public class ListExclusiones : IListExclusiones
    {

        private readonly IExclusionesRepository _context;
        private readonly IMapper _mapper;

        public ListExclusiones(IExclusionesRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<ExclusionDto> Execute()
        {  
            return _context.GetExclusiones().Select( registro=> _mapper.Map<Exclusion,ExclusionDto>(registro));
        }
    }
}
