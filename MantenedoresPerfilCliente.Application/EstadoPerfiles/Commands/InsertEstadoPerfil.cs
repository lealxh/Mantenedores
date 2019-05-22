using AutoMapper;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands
{
    public class InsertEstadoPerfil: IInsertEstadoPerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertEstadoPerfil(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(EstadoPerfilInsertDto dto)
        {
            var registro = _mapper.Map<EstadoPerfilInsertDto, EstadoPerfil>(dto);
            _context.EstadoPerfiles.Add(registro);
            _context.Save();
        }

    }
}