using AutoMapper;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.Universos.Queries
{
    public class ListUniversos : IListUniversos
    {

        private readonly IUniversoRepository _context;
        private readonly IMapper _mapper;

        public ListUniversos(IUniversoRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<UniversoDto> Execute()
        {  
            return _context.GetAll().Select( estado=> _mapper.Map<Universo,UniversoDto>(estado));
        }
    }
}
