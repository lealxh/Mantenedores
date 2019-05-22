using AutoMapper;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Queries
{
    public class ListTipoPerfiles : IListTipoPerfiles
    {

        private readonly ITipoPerfilRepository _context;
        private readonly IMapper _mapper;

        public ListTipoPerfiles(ITipoPerfilRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<TipoPerfilDto> Execute()
        {  
            return _context.GetAll().Select( estado=> _mapper.Map<TipoPerfil,TipoPerfilDto>(estado));
        }
    }
}
