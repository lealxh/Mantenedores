using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using System.Collections.Generic;
namespace MantenedoresPerfilCliente.BFF.Dtos
{
    public class ExlusionesLoadDto
    {
        public IEnumerable<ExclusionDto> Exclusiones { get; set; }
        public IEnumerable<AreaDto> Areas { get; set; }
        public IEnumerable<CargoDto> Cargos { get; set; }
        public IEnumerable<MotivoBloqueoDto> Motivos { get; set; }
    }
}
