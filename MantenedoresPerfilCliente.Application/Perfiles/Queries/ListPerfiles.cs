using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.Perfiles.Queries
{
    public class ListPerfiles : IListPerfiles
    {

        private readonly IPerfilesRepository _context;
        private readonly IMapper _mapper;

        public ListPerfiles(IPerfilesRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<PerfilDto> Execute()
        {  
            return _context.GetPerfiles().Select( registro=> _mapper.Map<Perfil,PerfilDto>(registro));
        }
    }
}
