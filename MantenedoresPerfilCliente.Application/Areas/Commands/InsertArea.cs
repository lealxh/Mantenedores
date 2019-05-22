using AutoMapper;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Interfaces;
using MantenedoresPerfilCliente.Domain.Entities;

namespace MantenedoresPerfilCliente.Application.Areas.Commands
{
    public class InsertArea : IInsertArea
    {
        private readonly IUnityOfWork _context;
        private readonly IMapper _mapper;
        public InsertArea(IUnityOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Execute(AreaInsertDto dto)
        {
            var registro = _mapper.Map<AreaInsertDto, Area>(dto);
            _context.Areas.Add(registro);
            _context.Save();
        }

    }
}