using MantenedoresPerfilCliente.Application.EstadoPerfiles.Commands;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.EstadoPerfiles.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MantenedoresPerfilCliente.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EstadoPerfilesController : ControllerBase
    {

      private readonly IListEstadoPerfiles _listEstadoPerfiles;
      private readonly IGetSingleEstadoPerfiles _getSingleEstadoPerfil;
      private readonly IUpdateEstadoPerfil _updateEstadoPerfil;
      private readonly IDeleteEstadoPerfil _deleteEstadoPerfil;
      private readonly IInsertEstadoPerfil _insertEstadoPerfil;
      private readonly ILogger<EstadoPerfilesController> _logger;

      public EstadoPerfilesController( IListEstadoPerfiles listEstadoPerfiles,
        IGetSingleEstadoPerfiles getSingleEstadoPerfil,
        IUpdateEstadoPerfil updateEstadoPerfil,
        IDeleteEstadoPerfil deleteEstadoPerfil,
        IInsertEstadoPerfil insertEstadoPerfil,
        ILogger<EstadoPerfilesController> logger)
      {
        _updateEstadoPerfil = updateEstadoPerfil;
        _deleteEstadoPerfil = deleteEstadoPerfil;
        _insertEstadoPerfil = insertEstadoPerfil;
        _listEstadoPerfiles = listEstadoPerfiles;
        _getSingleEstadoPerfil = getSingleEstadoPerfil;
        _logger = logger;



      }

      [HttpGet( Name = "GetEstadoPerfiles")]
      public IActionResult Get()
      {
        return Ok(_listEstadoPerfiles.Execute());
      }


      // GET: api/EstadoPerfiles/5
      [HttpGet("{id}", Name = "GetEstadoPerfilById")]
      public ActionResult Get(int id)
      {
       
          return Ok(_getSingleEstadoPerfil.Execute(id));   

      }

      // POST: api/EstadoPerfiles
      [HttpPost]
      public ActionResult Post(EstadoPerfilInsertDto dto)
      {
        _insertEstadoPerfil.Execute(dto);
        _logger.LogInformation(string.Format("EstadoPerfil Id:{0} Creada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

      [HttpPut]
      public ActionResult Put(EstadoPerfilUpdateDto dto)
      {
        _updateEstadoPerfil.Execute(dto);
        _logger.LogInformation(string.Format("EstadoPerfil Id:{0} Modificada por Usuario: {1} ",dto.Id,dto.Identity));
        return Ok();
      }

        
      [HttpDelete("{id}",Name="DeleteEstadoPerfil")]
      public ActionResult Delete(int id)
      {
       
          _deleteEstadoPerfil.Execute(new EstadoPerfilDeleteDto(){ Id=id});
          //_logger.LogInformation(string.Format("EstadoPerfil Id:{0} Eliminada por Usuario: {1} ",dto.Id,dto.Identity));
          return Ok();
       
      }
    }
}
