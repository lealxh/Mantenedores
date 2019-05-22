using MantenedoresPerfilCliente.Application.Perfiles.Commands;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
  [Route("api/[Controller]")]
    [ApiController]
    public class PerfilesController : ControllerBase
    {

      private readonly IListPerfiles _listPerfiles;
      private readonly IGetSinglePerfil _getSinglePerfil;
      private readonly IUpdatePerfil _updatePerfil;
      private readonly IDeletePerfil _deletePerfil;
      private readonly IInsertPerfil _insertPerfil;
  
      private readonly ILogger<PerfilesController> _logger;
      private readonly IValidateCodigoPerfil _validateCodigoPerfil;

      public PerfilesController( IListPerfiles listPerfiles,
        IGetSinglePerfil getSinglePerfil,
        IUpdatePerfil updatePerfil,
        IDeletePerfil deletePerfil,
        IInsertPerfil insertPerfil,
        IValidateCodigoPerfil validateCodigoPerfil,
        ILogger<PerfilesController> logger)
      {
        _validateCodigoPerfil = validateCodigoPerfil;
        _updatePerfil = updatePerfil;
        _deletePerfil = deletePerfil;
        _insertPerfil = insertPerfil;
        _listPerfiles = listPerfiles;
        _getSinglePerfil = getSinglePerfil;
        _logger = logger;



      }
      // GET: api/Perfils
      [HttpGet( Name = "GetPerfiles")]
      public IActionResult Get()
      {
        return Ok(_listPerfiles.Execute());
      }


      // GET: api/Perfils/5
      [HttpGet("{id}", Name = "GetPerfilById")]
      public ActionResult Get(int id)
      {
        return Ok(_getSinglePerfil.Execute(id));
       
      }
      [HttpGet,Route("EsCodigoOcupado/{codigo}")]
      public ActionResult EsCodigoOcupado(int codigo)
      {
                 
        return Ok(_validateCodigoPerfil.Execute(codigo));
                  
      }


      // POST: api/Perfils
      [HttpPost]
      public ActionResult Post(PerfilInserDto dto)
      {
        _insertPerfil.Execute(ref dto);
        _logger.LogInformation(string.Format("Perfil Codigo:{0} Creado por Usuario:{1} ",dto.Codigo,dto.Identity));

        return Ok(dto);
      }

      [HttpPut]
      public ActionResult Put(PerfilUpdateDto dto)
      {
        _updatePerfil.Execute(dto);
        _logger.LogInformation(string.Format("Perfil Id:{0} Modificado por Usuario:{1} ",dto.Id,dto.Identity));

        return Ok(dto);
      }

        
      [HttpDelete("{id}",Name = "DeletePerfil")]
      public ActionResult Delete(int id)
      {
          
          _deletePerfil.Execute(new PerfilDeleteDto(){Id = id});
      
          return Ok();
       
      }
    }
}
