using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public class GetSingleFiltro : IGetSingleFiltro
    {
        private readonly IFiltrosRepository _context;
        private readonly IMapper _mapper;

        public GetSingleFiltro(IFiltrosRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public FiltroDto Execute(int id)
        {
            var registro = _context.GetFiltro(id);
            if(registro==null)
                throw new EntityNotFoundException("Filtro",id.ToString());
            return _mapper.Map<Filtro,FiltroDto>(registro);
        }

        
    }
}