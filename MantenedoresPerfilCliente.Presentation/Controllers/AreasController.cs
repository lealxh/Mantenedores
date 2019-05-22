using MantenedoresPerfilCliente.Application.Areas.Commands;
using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Areas.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {

      private readonly IListAreas _listAreas;
      private readonly IGetSingleArea _getSingleArea;
      private readonly IUpdateArea _updateArea;
      private readonly IDeleteArea _deleteArea;
      private readonly IInsertArea _insertArea;
      private readonly ILogger<AreasController> _logger;

      public AreasController( IListAreas listAreas,
        IGetSingleArea getSingleArea,
        IUpdateArea updateArea,
        IDeleteArea deleteArea,
        IInsertArea insertArea,
        ILogger<AreasController> logger)
      {
        _updateArea = updateArea;
        _deleteArea = deleteArea;
        _insertArea = insertArea;
        _listAreas = listAreas;
        _getSingleArea = getSingleArea;
        _logger = logger;



      }

      [HttpGet( Name = "GetAreas")]
      public IActionResult Get()
      {
        return Ok(_listAreas.Execute());
      }


      // GET: api/Areas/5
      [HttpGet("{id}", Name = "GetAreaById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleArea.Execute(id));   

      }

      // POST: api/Areas
      [HttpPost]
      public ActionResult Post(AreaInsertDto dto)
      {
        _insertArea.Execute(dto);
        _logger.LogInformation(string.Format("Area Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(AreaUpdateDto dto)
      {
        _updateArea.Execute(dto);
        _logger.LogInformation(string.Format("Area Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
      [HttpDelete("{id}",Name="DeleteArea")]
      public ActionResult Delete(int id)
      {
       
          _deleteArea.Execute(new AreaDeleteDto(){ Id=id});
         // _logger.LogInformation(string.Format("Area Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
