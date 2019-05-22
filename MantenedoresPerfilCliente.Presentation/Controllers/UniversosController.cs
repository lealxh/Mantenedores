using MantenedoresPerfilCliente.Application.Universos.Commands;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
using MantenedoresPerfilCliente.Application.Universos.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UniversosController : ControllerBase
    {

      private readonly IListUniversos _listUniversos;
      private readonly IGetSingleUniversos _getSingleUniverso;
      private readonly IUpdateUniverso _updateUniverso;
      private readonly IDeleteUniverso _deleteUniverso;
      private readonly IInsertUniverso _insertUniverso;
      private readonly ILogger<UniversosController> _logger;

      public UniversosController( IListUniversos listUniversos,
        IGetSingleUniversos getSingleUniverso,
        IUpdateUniverso updateUniverso,
        IDeleteUniverso deleteUniverso,
        IInsertUniverso insertUniverso,
        ILogger<UniversosController> logger)
      {
        _updateUniverso = updateUniverso;
        _deleteUniverso = deleteUniverso;
        _insertUniverso = insertUniverso;
        _listUniversos = listUniversos;
        _getSingleUniverso = getSingleUniverso;
        _logger = logger;



      }

      [HttpGet( Name = "GetUniversos")]
      public IActionResult Get()
      {
        return Ok(_listUniversos.Execute());
      }


      // GET: api/Universos/5
      [HttpGet("{id}", Name = "GetUniversoById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleUniverso.Execute(id));   

      }

      // POST: api/Universos
      [HttpPost]
      public ActionResult Post(UniversoInsertDto dto)
      {
        _insertUniverso.Execute(dto);
        _logger.LogInformation(string.Format("Universo Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(UniversoUpdateDto dto)
      {
        _updateUniverso.Execute(dto);
        _logger.LogInformation(string.Format("Universo Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
     [HttpDelete("{id}",Name="DeleteUniverso")]
      public ActionResult Delete(int id)
      {
          _deleteUniverso.Execute(new UniversoDeleteDto(){ Id=id});
         // _logger.LogInformation(string.Format("Universo Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
