using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Areas.Queries
{
    public class GetSingleArea:IGetSingleArea
    {
        private readonly IAreasRepository _context;
        private readonly IMapper _mapper;

        public GetSingleArea(IAreasRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public AreaDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("Area",id.ToString());
            return _mapper.Map<Area,AreaDto>(registro);
        }

        
    }
}