using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries
{
    public class ListMotivoBloqueos : IListMotivoBloqueos
    {

        private readonly IMotivosBloqueoRepository _context;
        private readonly IMapper _mapper;

        public ListMotivoBloqueos(IMotivosBloqueoRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<MotivoBloqueoDto> Execute()
        {  
            return _context.GetAll().Select( estado=> _mapper.Map<MotivoBloqueo,MotivoBloqueoDto>(estado));
        }
    }
}
