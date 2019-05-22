using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Filtros.Queries
{
    public class ValidateCodigoFiltro : IValidateCodigoFiltro
    {
        private readonly IFiltrosRepository _context;

        public ValidateCodigoFiltro(IFiltrosRepository context)
        {
            _context = context;
        }

        public bool Execute(int codigo)
        {
         
            return _context.Count(x=>x.Codigo==codigo && x.EstadoFiltro.Cod=="A") > 0;

        }

        
    }
}