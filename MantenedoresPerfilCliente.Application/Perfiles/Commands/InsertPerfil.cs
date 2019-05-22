using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Perfiles.Commands
{
    public class InsertPerfil : IInsertPerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;

        public InsertPerfil(IUnityOfWork context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Execute(ref PerfilInserDto dto)
        {
            var registro = _mapper.Map<PerfilInserDto, Perfil>(dto);
            _context.Perfiles.Add(registro);
            _context.Save();

            dto.Id = registro.Id;
            
        }

    }
}