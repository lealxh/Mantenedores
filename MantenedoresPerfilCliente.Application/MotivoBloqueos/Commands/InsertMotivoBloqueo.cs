using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public class InsertMotivoBloqueo : IInsertMotivoBloqueo
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertMotivoBloqueo(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(MotivoBloqueoInsertDto dto)
        {
            var registro = _mapper.Map<MotivoBloqueoInsertDto, MotivoBloqueo>(dto);
            _context.MotivosBloqueo.Add(registro);
            _context.Save();
        }

    }
}