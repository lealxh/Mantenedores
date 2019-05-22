using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using System.Collections.Generic;


namespace MantenedoresPerfilCliente.BFF.Dtos
{
    public class PerfilesLoadDTO
    {
        public IEnumerable<PerfilDto> Perfiles { get; set; }
        public IEnumerable<TipoPerfilDto> TiposPerfil { get; set; }
        public IEnumerable<EstadoPerfilDto> EstadosPerfil { get; set; }
        
        
    }
}
