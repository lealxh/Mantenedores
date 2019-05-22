using MantenedoresPerfilCliente.Application.Exclusiones.Commands;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.Exclusiones.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
  [Route("api/[Controller]")]
    [ApiController]
    public class ExclusionesController : ControllerBase
    {

      private readonly IListExclusiones _listExclusiones;
      private readonly IGetSingleExclusion _getSingleExclusion;
      private readonly IUpdateExclusion _updateExclusion;
      private readonly IDeleteExclusion _deleteExclusion;
      private readonly IInsertExclusion _insertExclusion;
      private readonly ILogger<ExclusionesController> _logger;

      public ExclusionesController( IListExclusiones listExclusiones,
        IGetSingleExclusion getSingleExclusion,
        IUpdateExclusion updateExclusion,
        IDeleteExclusion deleteExclusion,
        IInsertExclusion insertExclusion,
        ILogger<ExclusionesController> logger)
      {
        _updateExclusion = updateExclusion;
        _deleteExclusion = deleteExclusion;
        _insertExclusion = insertExclusion;
        _listExclusiones = listExclusiones;
        _getSingleExclusion = getSingleExclusion;
        _logger = logger;



      }

      [HttpGet( Name = "GetExclusiones")]
      public IActionResult Get()
      {
        return Ok(_listExclusiones.Execute());
      }


      // GET: api/Exclusions/5
      [HttpGet("{id}", Name = "GetExclusionById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleExclusion.Execute(id));   

      }

      // POST: api/Exclusions
      [HttpPost]
      public ActionResult Post(ExclusionInsertDto dto)
      {
        _insertExclusion.Execute(dto);
        _logger.LogInformation(string.Format("Exclusion Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(ExclusionUpdateDto dto)
      {
        _updateExclusion.Execute(dto);
        _logger.LogInformation(string.Format("Exclusion Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
        [HttpDelete("{id}",Name="DeleteExclusion")]
      public ActionResult Delete(int id)
      {
       
          _deleteExclusion.Execute(new ExclusionDeleteDto(){ Id=id});
         //_logger.LogInformation(string.Format("Exclusion Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
