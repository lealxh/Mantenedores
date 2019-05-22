using AutoMapper;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.TipoPerfiles.Commands
{
    public class InsertTipoPerfil : IInsertTipoPerfil
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertTipoPerfil(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(TipoPerfilInsertDto dto)
        {
            var registro = _mapper.Map<TipoPerfilInsertDto, TipoPerfil>(dto);
            _context.TiposPerfil.Add(registro);
            _context.Save();
        }

    }
}