using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries
{
    public class GetSingleEstadoPerfiles:IGetSingleEstadoPerfiles
    {
        private readonly IEstadoPerfilRepository _context;
        private readonly IMapper _mapper;

        public GetSingleEstadoPerfiles(IEstadoPerfilRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public EstadoPerfilDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("EstadoPerfiles",id.ToString());
            return _mapper.Map<EstadoPerfil,EstadoPerfilDto>(registro);
        }

        
    }
}