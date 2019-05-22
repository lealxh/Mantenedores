

using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
using MantenedoresPerfilCliente.BFF.Dtos;
using MantenedoresPerfilCliente.BFF.RestClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;

namespace MantenedoresPerfilCliente.BFF.Controllers
{
    [EnableCors("CORSPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesBFFController : ControllerBase
    {
      
            private readonly ILogger<PerfilesBFFController> _logger;
            private readonly IConfiguration _configuration;

            public PerfilesBFFController(ILogger<PerfilesBFFController> logger, IConfiguration configuration)
            {
          
               this._logger = logger;
               this._configuration = configuration;
            }

            private ActionResult convertMessage(HttpResponseMessage message,object content)
            { 
                 switch (message.StatusCode)
                 {
                    case System.Net.HttpStatusCode.OK:
                         return new OkObjectResult(content);
                      
                    case System.Net.HttpStatusCode.Created:
                         return new CreatedResult(message.RequestMessage.RequestUri,message.ContentAsJson());

                     case System.Net.HttpStatusCode.BadRequest:
                         return BadRequest();

                    case System.Net.HttpStatusCode.Unauthorized:
                         return Unauthorized();
                      
                    case System.Net.HttpStatusCode.NotFound:
                         return NotFound();
   
                    default:
                         return new StatusCodeResult( ((int)message.StatusCode));
                            
                          
                 }
            
            }
          
          [HttpGet(Name = "PerfilesLoad"),Route("{loadAll}")]
          public ActionResult PerfilesLoad(bool loadAll)
          {
                 PerfilesLoadDTO ret= new PerfilesLoadDTO(){ 
                 Perfiles=new List<PerfilDto>(),
                 EstadosPerfil=new List<EstadoPerfilDto>(),
                 TiposPerfil= new List<TipoPerfilDto>()};
        
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
          
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:Perfiles"],token).Result;
                 _logger.LogInformation(string.Format("GetPerfiles: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 ret.Perfiles = response0.ContentAsType<List<PerfilDto>>();
                
                if(response0.IsSuccessStatusCode)
                {
                    if(loadAll)
                    { 
                        var response1= HttpRequestFactory.Get(_configuration["Endpoints:TipoPerfiles"],token).Result;
                       _logger.LogInformation(string.Format("GetTiposPerfiles: StatusCode:{0} , RequestMessage:{1} ",response1.StatusCode,response1.RequestMessage));
                        ret.TiposPerfil = response1.ContentAsType<List<TipoPerfilDto>>();

                        var response2=  HttpRequestFactory.Get(_configuration["Endpoints:EstadoPerfiles"],token).Result;
                        _logger.LogInformation(string.Format("GetEstadosPerfiles: StatusCode:{0} , RequestMessage:{1} ",response2.StatusCode,response2.RequestMessage));
                        ret.EstadosPerfil = response2.ContentAsType<List<EstadoPerfilDto>>();

                    }
                }

                return convertMessage(response0,ret);
              
            }
           

        // POST: api/Perfils
          [HttpPost(Name = "CreatePerfil")]
          public ActionResult CreatePerfil(PerfilInserDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:Perfiles"],dto,token).Result;
                _logger.LogInformation(string.Format("CreatePerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<PerfilDto>());
          }

          [HttpPut(Name = "UpdatePerfil")]
          public ActionResult UpdatePerfil(PerfilUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:Perfiles"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdatePerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<PerfilUpdateDto>());
          }

        
          [HttpDelete("{id}", Name = "DeletePerfil")]
          public ActionResult DeletePerfil(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:Perfiles"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeletePerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                
                return convertMessage(response, response.ContentAsType<PerfilUpdateDto>());
            
       
          }
    }
}