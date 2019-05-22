using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Filtros.Commands
{
    public class UpdateFiltro : IUpdateFiltro
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateFiltro(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(FiltroUpdateDto dto)
        {
            var registro = _context.Filtros.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Filtro", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}