using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Filtro, FiltroDto>()
                .ForMember(x => x.PerfilDescripcion, opt => opt.MapFrom(y => y.Perfil.Descripcion))
                .ForMember(x => x.EstadoFiltroDescripcion, opt => opt.MapFrom(y => y.EstadoFiltro.Descripcion))
                .ForMember(x => x.UniversoDescripcion, opt => opt.MapFrom(y => y.Universo.Descripcion));
            
            CreateMap<FiltroDto, Filtro>().ForMember(x=>x.Id, opt => opt.Ignore());


            CreateMap<FiltroInsertDto, Filtro>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<FiltroUpdateDto, Filtro>().ForMember(x=>x.Id, opt => opt.Ignore());


            CreateMap<Perfil, PerfilDto>()
                .ForMember(x => x.EstadoPerfilDescripcion, opt => opt.MapFrom(y => y.EstadoPerfil.Descripcion))
                .ForMember(x => x.TipoPerfilDescripcion, opt => opt.MapFrom(y => y.TipoPerfil.Descripcion));

            CreateMap<PerfilDto, Perfil>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<PerfilInserDto, Perfil>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<PerfilUpdateDto, Perfil>().ForMember(x=>x.Id, opt => opt.Ignore());

            
            CreateMap<Exclusion, ExclusionDto>().
                ForMember(x=>x.CargoNombre,opt=>opt.MapFrom(y=>y.Cargo.Descripcion)).
                ForMember(x=>x.AreaNombre,opt=>opt.MapFrom(y=>y.Area.Nombre)).
                ForMember(x=>x.MotivoBloqueoDescripcion,opt=>opt.MapFrom(x=>x.MotivoBloqueo.Descripcion)).
                ForMember(x=>x.TipoBloqueo,opt=>opt.MapFrom(x=>x.MotivoBloqueo.TipoBloqueo));
           
            CreateMap<ExclusionDto, Exclusion>();
            CreateMap<ExclusionInsertDto, Exclusion>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<ExclusionUpdateDto, Exclusion>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>();
            CreateMap<AreaInsertDto, Area>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<AreaUpdateDto, Area>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();
            CreateMap<CargoInsertDto, Cargo>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<CargoUpdateDto, Cargo>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<EstadoFiltro, EstadoFiltroDto>();
            CreateMap<EstadoFiltroDto, EstadoFiltro>();
            CreateMap<EstadoFiltroInsertDto, EstadoFiltro>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<EstadoFiltroUpdateDto, EstadoFiltro>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<EstadoPerfil, EstadoPerfilDto>();
            CreateMap<EstadoPerfilDto, EstadoPerfil>();
            CreateMap<EstadoPerfilInsertDto, EstadoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<EstadoPerfilUpdateDto, EstadoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<TipoPerfil, TipoPerfilDto>();
            CreateMap<TipoPerfilDto, TipoPerfil>();
            CreateMap<TipoPerfilInsertDto, TipoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<TipoPerfilUpdateDto, TipoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<Universo, UniversoDto>();
            CreateMap<UniversoDto, Universo>();
            CreateMap<UniversoInsertDto, Universo>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<UniversoUpdateDto, TipoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());

            CreateMap<MotivoBloqueo, MotivoBloqueoDto>();
            CreateMap<MotivoBloqueoDto, MotivoBloqueo>();
            CreateMap<MotivoBloqueoInsertDto, MotivoBloqueo>().ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<MotivoBloqueoUpdateDto, TipoPerfil>().ForMember(x=>x.Id, opt => opt.Ignore());


           


        }
    }

}
