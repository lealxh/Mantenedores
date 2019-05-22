using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public class ValidateOrdenFiltro : IValidateOrdenFiltro
    {
        private readonly IFiltrosRepository _context;
        private readonly IMapper _mapper;

        public ValidateOrdenFiltro(IFiltrosRepository context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public bool Execute(int orden)
        {
            return _context.Count(x => x.Orden == orden && x.EstadoFiltro.Cod=="A") > 0;

        }

        
    }
}