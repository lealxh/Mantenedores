using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public class InsertEstadoFiltro : IInsertEstadoFiltro
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertEstadoFiltro(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(EstadoFiltroInsertDto dto)
        {
            var registro = _mapper.Map<EstadoFiltroInsertDto, EstadoFiltro>(dto);
            _context.EstadoFiltros.Add(registro);
            _context.Save();
        }

    }
}