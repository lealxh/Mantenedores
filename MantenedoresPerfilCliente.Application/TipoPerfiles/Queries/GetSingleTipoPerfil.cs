using AutoMapper;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Queries
{
    public class GetSingleTipoPerfiles:IGetSingleTipoPerfiles
    {
        private readonly ITipoPerfilRepository _context;
        private readonly IMapper _mapper;

        public GetSingleTipoPerfiles(ITipoPerfilRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public TipoPerfilDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("TipoPerfiles",id.ToString());
            return _mapper.Map<TipoPerfil,TipoPerfilDto>(registro);
        }

        
    }
}