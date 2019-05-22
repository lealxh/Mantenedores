using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public class UpdateArea : IUpdateArea
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateArea(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(AreaUpdateDto dto)
        {
            var registro = _context.Areas.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Area", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

        }

    }
}