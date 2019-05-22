using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Perfiles.Queries
{
    public class ValidateCodigoPerfil : IValidateCodigoPerfil
    {
        private readonly IPerfilesRepository _context;

        public ValidateCodigoPerfil(IPerfilesRepository context)
        {
            _context = context;
        }

        public bool Execute(int codigo)
        {
         
            return _context.Count(x=>x.Codigo==codigo && x.EstadoPerfil.Cod=="A") > 0;

        }

        
    }
}