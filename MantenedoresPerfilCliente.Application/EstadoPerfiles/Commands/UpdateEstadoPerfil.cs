using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public class UpdateEstadoPerfil : IUpdateEstadoPerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateEstadoPerfil(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(EstadoPerfilUpdateDto dto)
        {
            var registro = _context.EstadoPerfiles.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("EstadoPerfil", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}