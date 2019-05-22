using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Perfiles.Queries
{
    public class GetSinglePerfil : IGetSinglePerfil
    {
        private readonly IPerfilesRepository _context;
        private readonly IMapper _mapper;

        public GetSinglePerfil(IPerfilesRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public PerfilDto Execute(int id)
        {
            var registro = _context.GetPerfil(id);
            if(registro==null)
                throw new EntityNotFoundException("Perfil",id.ToString());
            return _mapper.Map<Perfil,PerfilDto>(registro);
        }

        
    }
}