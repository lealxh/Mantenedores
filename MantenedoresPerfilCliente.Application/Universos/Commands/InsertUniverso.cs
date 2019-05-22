using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public class InsertUniverso : IInsertUniverso
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertUniverso(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(UniversoInsertDto dto)
        {
            var registro = _mapper.Map<UniversoInsertDto, Universo>(dto);
            _context.Universos.Add(registro);
            _context.Save();
        }

    }
}