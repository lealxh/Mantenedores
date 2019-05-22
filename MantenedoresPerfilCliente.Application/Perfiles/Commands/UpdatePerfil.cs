using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public class UpdatePerfil : IUpdatePerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdatePerfil(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(PerfilUpdateDto dto)
        {
            var registro = _context.Perfiles.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Perfil", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}