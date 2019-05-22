using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.EstadoFiltros.Commands
{
    public class UpdateEstadoFiltro : IUpdateEstadoFiltro
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateEstadoFiltro(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(EstadoFiltroUpdateDto dto)
        {
            var registro = _context.EstadoFiltros.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("EstadoFiltro", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}