using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;

namespace MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands
{
    public class UpdateMotivoBloqueo : IUpdateMotivoBloqueo
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateMotivoBloqueo(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(MotivoBloqueoUpdateDto dto)
        {
            var registro = _context.MotivosBloqueo.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("MotivoBloqueo", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}