

using MantenedoresPerfilCliente.Application.EstadoPerfiles.Dtos;
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
    public class EstadoPerfilesBFFController : ControllerBase
    {
      
            private readonly ILogger<EstadoPerfilesBFFController> _logger;
            private readonly IConfiguration _configuration;

            public EstadoPerfilesBFFController(ILogger<EstadoPerfilesBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet(Name = "EstadoPerfilesLoad")]
          public ActionResult EstadoPerfilesLoad()
          {
                
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:EstadoPerfiles"],token).Result;
                 _logger.LogInformation(string.Format("GetEstadoPerfiles: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<List<EstadoPerfilDto>>();
      
                return convertMessage(response0,ret);
              
            }
           

   
          [HttpPost(Name = "CreateEstadoPerfil")]
          public ActionResult CreateEstadoPerfil(EstadoPerfilInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:EstadoPerfiles"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateEstadoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<EstadoPerfilInsertDto>());
          }

          [HttpPut(Name = "UpdateEstadoPerfil")]
          public ActionResult UpdateEstadoPerfil(EstadoPerfilUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:EstadoPerfiles"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateEstadoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<EstadoPerfilUpdateDto>());
          }

        
          [HttpDelete("{id}" , Name = "DeleteEstadoPerfil")]
          public ActionResult DeleteEstadoPerfil(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:EstadoPerfiles"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteEstadoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage)); 
                return convertMessage(response, response.ContentAsJson());
           
       
          }
    }
}