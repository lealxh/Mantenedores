using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries
{
    public class ListEstadoPerfiles : IListEstadoPerfiles
    {

        private readonly IEstadoPerfilRepository _context;
        private readonly IMapper _mapper;

        public ListEstadoPerfiles(IEstadoPerfilRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<EstadoPerfilDto> Execute()
        {  
            return _context.GetAll().Select( estado=> _mapper.Map<EstadoPerfil,EstadoPerfilDto>(estado));
        }
    }
}
