using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Queries
{
    public class GetSingleExclusion : IGetSingleExclusion
    {
        private readonly IExclusionesRepository _context;
        private readonly IMapper _mapper;

        public GetSingleExclusion(IExclusionesRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ExclusionDto Execute(int id)
        {
            var registro = _context.GetExclusion(id);
            if(registro==null)
                throw new EntityNotFoundException("Exclusion",id.ToString());
            
            return _mapper.Map<Exclusion,ExclusionDto>(registro);
        }

        
    }
}