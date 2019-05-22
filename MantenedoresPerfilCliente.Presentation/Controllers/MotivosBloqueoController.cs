using MantenedoresPerfilCliente.Application.MotivoBloqueos.Commands;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MotivosBloqueoController : ControllerBase
    {

      private readonly IListMotivoBloqueos _listMotivoBloqueos;
      private readonly IGetSingleMotivoBloqueos _getSingleMotivoBloqueo;
      private readonly IUpdateMotivoBloqueo _updateMotivoBloqueo;
      private readonly IDeleteMotivoBloqueo _deleteMotivoBloqueo;
      private readonly IInsertMotivoBloqueo _insertMotivoBloqueo;
      private readonly ILogger<MotivosBloqueoController> _logger;

      public MotivosBloqueoController(IListMotivoBloqueos listMotivoBloqueos,
        IGetSingleMotivoBloqueos getSingleMotivoBloqueo,
        IUpdateMotivoBloqueo updateMotivoBloqueo,
        IDeleteMotivoBloqueo deleteMotivoBloqueo,
        IInsertMotivoBloqueo insertMotivoBloqueo,
        ILogger<MotivosBloqueoController> logger)
      {
        _updateMotivoBloqueo = updateMotivoBloqueo;
        _deleteMotivoBloqueo = deleteMotivoBloqueo;
        _insertMotivoBloqueo = insertMotivoBloqueo;
        _listMotivoBloqueos = listMotivoBloqueos;
        _getSingleMotivoBloqueo = getSingleMotivoBloqueo;
        _logger = logger;



      }

      [HttpGet( Name = "GetMotivoBloqueos")]
      public IActionResult Get()
      {
        return Ok(_listMotivoBloqueos.Execute());
      }


      // GET: api/MotivoBloqueos/5
      [HttpGet("{id}", Name = "GetMotivoBloqueoById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleMotivoBloqueo.Execute(id));   

      }

      // POST: api/MotivoBloqueos
      [HttpPost]
      public ActionResult Post(MotivoBloqueoInsertDto dto)
      {
        _insertMotivoBloqueo.Execute(dto);
        _logger.LogInformation(string.Format("MotivoBloqueo Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(MotivoBloqueoUpdateDto dto)
      {
        _updateMotivoBloqueo.Execute(dto);
        _logger.LogInformation(string.Format("MotivoBloqueo Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
       [HttpDelete("{id}",Name="DeletemotivoBloqueo")]
      public ActionResult Delete(int id)
      {
       
          _deleteMotivoBloqueo.Execute(new MotivoBloqueoDeleteDto(){ Id=id});
          //_logger.LogInformation(string.Format("MotivoBloqueo Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
