using AutoMapper;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Universos.Queries
{
    public class GetSingleUniversos:IGetSingleUniversos
    {
        private readonly IUniversoRepository _context;
        private readonly IMapper _mapper;

        public GetSingleUniversos(IUniversoRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public UniversoDto Execute(int id)
        {
            var registro = _context.Get(id);
            if(registro==null)
                throw new EntityNotFoundException("Universos",id.ToString());
            return _mapper.Map<Universo,UniversoDto>(registro);
        }

        
    }
}