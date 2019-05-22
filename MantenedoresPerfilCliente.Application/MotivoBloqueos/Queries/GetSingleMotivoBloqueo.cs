using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries
{
    public class GetSingleMotivoBloqueos:IGetSingleMotivoBloqueos
    {
        private readonly IMotivosBloqueoRepository _context;
        private readonly IMapper _mapper;

        public GetSingleMotivoBloqueos(IMotivosBloqueoRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public MotivoBloqueoDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("MotivoBloqueos",id.ToString());
            return _mapper.Map<MotivoBloqueo,MotivoBloqueoDto>(registro);
        }

        
    }
}