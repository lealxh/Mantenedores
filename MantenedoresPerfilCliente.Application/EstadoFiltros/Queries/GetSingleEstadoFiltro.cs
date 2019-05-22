using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Queries
{
    public class GetSingleEstadoFiltro:IGetSingleEstadoFiltro
    {
        private readonly IEstadoFiltroRepository _context;
        private readonly IMapper _mapper;

        public GetSingleEstadoFiltro(IEstadoFiltroRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public EstadoFiltroDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("EstadoFiltro",id.ToString());
            return _mapper.Map<EstadoFiltro,EstadoFiltroDto>(registro);
        }

        
    }
}