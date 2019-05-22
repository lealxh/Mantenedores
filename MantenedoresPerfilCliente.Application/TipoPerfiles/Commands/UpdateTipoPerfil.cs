using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public class UpdateTipoPerfil : IUpdateTipoPerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateTipoPerfil(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(TipoPerfilUpdateDto dto)
        {
            var registro = _context.TiposPerfil.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("TipoPerfil", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}