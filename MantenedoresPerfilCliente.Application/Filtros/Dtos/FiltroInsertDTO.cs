using MantenedoresPerfilCliente.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MantenedoresPerfilCliente.Application.Filtros.Dtos
{
    public class FiltroInsertDto:IDto
    {
        public int Id { get; set; }

        [Required,Display(Name="Codigo")]
        public int Codigo { get; set; }

        [Required, MaxLength(255),Display(Name = "Filtro")]
        public string Descripcion { get; set; }

        //public EstadoFiltro EstadoFiltro { get; set; }
        [Display(Name = "Estado Filtro")]
        public int EstadoFiltroId { get; set; }

        //public Perfil Perfil { get; set; }

        [Display(Name = "Perfil")]
        public int PerfilId { get; set; }

        [Display(Name = "Universo")]
        public int UniversoId { get; set; }

        [Required]
        public int Orden { get; set; }

        [Display(Name = "Corte 1")]
        public int? Corte1 { get; set; }
        
        [Display(Name = "Corte 2")]
        public int? Corte2 { get; set; }

        [Display(Name = "Monto 1")]
        public double? Monto1 { get; set; }

        [Display(Name = "Monto 2")]
        public double? Monto2 { get; set; }

        public string Identity { get; set; }
    }
}
