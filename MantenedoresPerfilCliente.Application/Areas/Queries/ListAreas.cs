using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.Areas.Queries
{
    public class ListAreas : IListAreas
    {

        private readonly IAreasRepository _context;
        private readonly IMapper _mapper;

        public ListAreas(IAreasRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<AreaDto> Execute()
        {  
            return _context.GetAll().Select( registro=> _mapper.Map<Area,AreaDto>(registro));
        }
    }
}
