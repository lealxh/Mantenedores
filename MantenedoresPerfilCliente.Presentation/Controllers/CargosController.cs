using MantenedoresPerfilCliente.Application.Cargos.Commands;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Cargos.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {

      private readonly IListCargos _listCargos;
      private readonly IGetSingleCargo _getSingleCargo;
      private readonly IUpdateCargo _updateCargo;
      private readonly IDeleteCargo _deleteCargo;
      private readonly IInsertCargo _insertCargo;
      private readonly ILogger<CargosController> _logger;

      public CargosController( IListCargos listCargos,
        IGetSingleCargo getSingleCargo,
        IUpdateCargo updateCargo,
        IDeleteCargo deleteCargo,
        IInsertCargo insertCargo,
        ILogger<CargosController> logger)
      {
        _updateCargo = updateCargo;
        _deleteCargo = deleteCargo;
        _insertCargo = insertCargo;
        _listCargos = listCargos;
        _getSingleCargo = getSingleCargo;
        _logger = logger;



      }

      [HttpGet( Name = "GetCargos")]
      public IActionResult Get()
      {
        return Ok(_listCargos.Execute());
      }


      // GET: api/Cargos/5
      [HttpGet("{id}", Name = "GetCargoById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleCargo.Execute(id));   

      }

      // POST: api/Cargos
      [HttpPost]
      public ActionResult Post(CargoInsertDto dto)
      {
        _insertCargo.Execute(dto);
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(CargoUpdateDto dto)
      {
        _updateCargo.Execute(dto);
        return Ok();
      }

        
       [HttpDelete("{id}",Name="DeleteCargo")]
      public ActionResult Delete(int id)
      {
       
          _deleteCargo.Execute(new CargoDeleteDto(){ Id=id});
          return Ok();
       
      }
    }
}
