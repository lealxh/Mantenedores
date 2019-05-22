using AutoMapper;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public class ListFiltros : IListFiltros
    {

        private readonly IFiltrosRepository _context;
        private readonly IMapper _mapper;

        public ListFiltros(IFiltrosRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<FiltroDto> Execute()
        {  
            return _context.GetFiltros().Select( registro=> _mapper.Map<Filtro,FiltroDto>(registro));
        }
    }
}
