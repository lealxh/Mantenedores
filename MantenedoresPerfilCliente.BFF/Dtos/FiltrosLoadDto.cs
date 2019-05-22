using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using System.Collections.Generic;

namespace MantenedoresPerfilCliente.BFF.Dtos
{
    public class FiltrosLoadDto
    {
        public IEnumerable<FiltroDto> Filtros { get; set; }
        public IEnumerable<EstadoFiltroDto> Estados { get; set; }
        public IEnumerable<UniversoDto> Universos { get; set; }
        public IEnumerable<PerfilDto> Perfiles { get; set; }

    }
}
