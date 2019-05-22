using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Universos.Dtos;

namespace MantenedoresPerfilCliente.Application.Universos.Commands
{
    public class UpdateUniverso : IUpdateUniverso
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateUniverso(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(UniversoUpdateDto dto)
        {
            var registro = _context.Universos.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Universo", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}