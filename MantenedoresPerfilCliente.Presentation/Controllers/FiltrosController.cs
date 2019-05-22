using MantenedoresPerfilCliente.Application.Filtros.Commands;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Filtros.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class FiltrosController : ControllerBase
  {
        private readonly IListFiltros _listFiltros;
        private readonly IGetSingleFiltro _getSingleFiltro;
        private readonly IUpdateFiltro _updateFiltro;
        private readonly IDeleteFiltro _deleteFiltro;
        private readonly IInsertFiltro _insertFiltro;
        private readonly IValidateCodigoFiltro _validateCodigoFiltro;
        private readonly IValidateOrdenFiltro _validateOrdenFiltro;
        private readonly ILogger<FiltrosController> _logger;  

        public FiltrosController( IListFiltros listFiltros,
                                 IGetSingleFiltro getSingleFiltro,
                                 IUpdateFiltro updateFiltro,
                                 IDeleteFiltro deleteFiltro,
                                 IInsertFiltro insertFiltro,
                                 IValidateCodigoFiltro validateCodigoFiltro,
                                 IValidateOrdenFiltro validateOrdenFiltro,
                                 ILogger<FiltrosController> logger)
        {
          _updateFiltro = updateFiltro;
          _deleteFiltro = deleteFiltro;
          _insertFiltro = insertFiltro;
          _listFiltros = listFiltros;
          _getSingleFiltro = getSingleFiltro;
          _logger = logger;
          _validateCodigoFiltro = validateCodigoFiltro;
          _validateOrdenFiltro = validateOrdenFiltro;



        }
       
        
        [HttpGet(Name = "GetFiltros")]
        public IActionResult Get()
        {
          return Ok(_listFiltros.Execute());
        }


        
        [HttpGet("{id}", Name = "GetFiltrosById")]
        public ActionResult Get(int id)
        {
         
            return Ok(_getSingleFiltro.Execute(id));
          
        }

        [HttpGet,Route("EsCodigoOcupado/{codigo}")]
        public ActionResult EsCodigoValido(int codigo)
        {
                 
          return Ok(_validateCodigoFiltro.Execute(codigo));
                  
        }

        [HttpGet,Route("EsOrdenOcupado/{orden}")]
        public ActionResult EsOrdenValido(int orden)
        {
                     
          return Ok(_validateOrdenFiltro.Execute(orden));
                      
        }

        // POST: api/Filtros
        [HttpPost]
        public ActionResult Post(FiltroInsertDto dto)
        {
           _insertFiltro.Execute(dto);
          _logger.LogInformation(string.Format("Filtro Id:{0} Creado por Usuario: {1} ",dto.Id,dto.Identity));
            return Ok();
        }

         [HttpPut]
        public ActionResult Put(FiltroUpdateDto dto)
        {
          _updateFiltro.Execute(dto);
          _logger.LogInformation(string.Format("Filtro Id:{0} Modificado por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
        }

        
        [HttpDelete("{id}",Name="DeleteFiltro")]
        public ActionResult Delete(int id)
        {
         
            _deleteFiltro.Execute(new FiltroDeleteDto(){Id = id});
            //_logger.LogInformation(string.Format("Filtro Id:{0} Eliminado por Usuario: {1} ",dto.Id,dto.Identity));
            return Ok();
         
        }
    }
}
