using AutoMapper;
using MantenedoresPerfilCliente.Application.Exceptions;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;

namespace MantenedoresPerfilCliente.Application.Exclusiones.Commands
{
    public class UpdateExclusion : IUpdateExclusion
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public UpdateExclusion(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(ExclusionUpdateDto dto)
        {
            var registro = _context.Exclusiones.SingleOrDefault(x => x.Id == dto.Id);

            if (registro == null)
                throw new EntityNotFoundException("Exclusion", dto.Id.ToString());

            _mapper.Map(dto, registro);

            _context.Save();

            

        }

    }
}