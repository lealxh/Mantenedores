using MantenedoresPerfilCliente.Application.EstadoFiltros.Commands;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.EstadoFiltros.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EstadoFiltrosController : ControllerBase
    {

      private readonly IListEstadoFiltros _listEstadoFiltros;
      private readonly IGetSingleEstadoFiltro _getSingleEstadoFiltro;
      private readonly IUpdateEstadoFiltro _updateEstadoFiltro;
      private readonly IDeleteEstadoFiltro _deleteEstadoFiltro;
      private readonly IInsertEstadoFiltro _insertEstadoFiltro;
      private readonly ILogger<EstadoFiltrosController> _logger;

      public EstadoFiltrosController( IListEstadoFiltros listEstadoFiltros,
        IGetSingleEstadoFiltro getSingleEstadoFiltro,
        IUpdateEstadoFiltro updateEstadoFiltro,
        IDeleteEstadoFiltro deleteEstadoFiltro,
        IInsertEstadoFiltro insertEstadoFiltro,
        ILogger<EstadoFiltrosController> logger)
      {
        _updateEstadoFiltro = updateEstadoFiltro;
        _deleteEstadoFiltro = deleteEstadoFiltro;
        _insertEstadoFiltro = insertEstadoFiltro;
        _listEstadoFiltros = listEstadoFiltros;
        _getSingleEstadoFiltro = getSingleEstadoFiltro;
        _logger = logger;



      }

      [HttpGet( Name = "GetEstadoFiltros")]
      public IActionResult Get()
      {
        return Ok(_listEstadoFiltros.Execute());
      }


      // GET: api/EstadoFiltros/5
      [HttpGet("{id}", Name = "GetEstadoFiltroById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleEstadoFiltro.Execute(id));   

      }

      // POST: api/EstadoFiltros
      [HttpPost]
      public ActionResult Post(EstadoFiltroInsertDto dto)
      {
        _insertEstadoFiltro.Execute(dto);
        _logger.LogInformation(string.Format("EstadoFiltro Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(EstadoFiltroUpdateDto dto)
      {
        _updateEstadoFiltro.Execute(dto);
        _logger.LogInformation(string.Format("EstadoFiltro Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
      [HttpDelete("{id}",Name="DeleteEstadoFiltro")]
      public ActionResult Delete(int id)
      {
       
          _deleteEstadoFiltro.Execute(new EstadoFiltroDeleteDto(){ Id=id});
         // _logger.LogInformation(string.Format("EstadoFiltro Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
