using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Queries
{
    public class ListEstadoFiltros : IListEstadoFiltros
    {

        private readonly IEstadoFiltroRepository _context;
        private readonly IMapper _mapper;

        public ListEstadoFiltros(IEstadoFiltroRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<EstadoFiltroDto> Execute()
        {  
            return _context.GetAll().Select( estado=> _mapper.Map<EstadoFiltro,EstadoFiltroDto>(estado));
        }
    }
}
