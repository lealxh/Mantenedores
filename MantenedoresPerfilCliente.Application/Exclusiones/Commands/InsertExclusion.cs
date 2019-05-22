using AutoMapper;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public class InsertExclusion : IInsertExclusion
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public InsertExclusion(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(ExclusionInsertDto dto)
        {
            var registro = _mapper.Map<ExclusionInsertDto, Exclusion>(dto);
            _context.Exclusiones.Add(registro);
            _context.Save();
        }

    }
}