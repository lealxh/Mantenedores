using MantenedoresPerfilCliente.Application.TipoPerfiles.Commands;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TipoPerfilesController : ControllerBase
    {

      private readonly IListTipoPerfiles _listTipoPerfiles;
      private readonly IGetSingleTipoPerfiles _getSingleTipoPerfil;
      private readonly IUpdateTipoPerfil _updateTipoPerfil;
      private readonly IDeleteTipoPerfil _deleteTipoPerfil;
      private readonly IInsertTipoPerfil _insertTipoPerfil;
      private readonly ILogger<TipoPerfilesController> _logger;

      public TipoPerfilesController( IListTipoPerfiles listTipoPerfiles,
        IGetSingleTipoPerfiles getSingleTipoPerfil,
        IUpdateTipoPerfil updateTipoPerfil,
        IDeleteTipoPerfil deleteTipoPerfil,
        IInsertTipoPerfil insertTipoPerfil,
        ILogger<TipoPerfilesController> logger)
      {
        _updateTipoPerfil = updateTipoPerfil;
        _deleteTipoPerfil = deleteTipoPerfil;
        _insertTipoPerfil = insertTipoPerfil;
        _listTipoPerfiles = listTipoPerfiles;
        _getSingleTipoPerfil = getSingleTipoPerfil;
        _logger = logger;



      }

      [HttpGet( Name = "GetTipoPerfiles")]
      public IActionResult Get()
      {
        return Ok(_listTipoPerfiles.Execute());
      }


      // GET: api/TipoPerfiles/5
      [HttpGet("{id}", Name = "GetTipoPerfilById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleTipoPerfil.Execute(id));   

      }

      // POST: api/TipoPerfiles
      [HttpPost]
      public ActionResult Post(TipoPerfilInsertDto dto)
      {
        _insertTipoPerfil.Execute(dto);
        _logger.LogInformation(string.Format("TipoPerfil Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(TipoPerfilUpdateDto dto)
      {
        _updateTipoPerfil.Execute(dto);
        _logger.LogInformation(string.Format("TipoPerfil Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
      [HttpDelete("{id}",Name="DeleteTipoPerfil")]
      public ActionResult Delete(int id)
      {
       
          _deleteTipoPerfil.Execute(new TipoPerfilDeleteDto(){ Id=id});
         // _logger.LogInformation(string.Format("TipoPerfil Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
