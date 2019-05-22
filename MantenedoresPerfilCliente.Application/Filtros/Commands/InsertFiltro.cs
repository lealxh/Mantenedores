using AutoMapper;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public class InsertFiltro : IInsertFiltro
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public InsertFiltro(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(FiltroInsertDto dto)
        {
            var registro = _mapper.Map<FiltroInsertDto, Filtro>(dto);
            
            _context.Filtros.Add(registro);
            _context.Save();
        }

    }
}