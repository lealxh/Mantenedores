

using MantenedoresPerfilCliente.Application.TipoPerfiles.Dtos;
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
    public class TipoPerfilesBFFController : ControllerBase
    {
      
            private readonly ILogger<TipoPerfilesBFFController> _logger;
            private readonly IConfiguration _configuration;

            public TipoPerfilesBFFController(ILogger<TipoPerfilesBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet(Name = "TipoPerfilesLoad")]
          public ActionResult TipoPerfilesLoad()
          {
                
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:TipoPerfiles"],token).Result;
                 _logger.LogInformation(string.Format("GetTipoPerfiles: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<List<TipoPerfilDto>>();
      
                return convertMessage(response0,ret);
              
            }
           

   
          [HttpPost(Name = "CreateTipoPerfil")]
          public ActionResult CreateTipoPerfil(TipoPerfilInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:TipoPerfiles"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateTipoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<TipoPerfilInsertDto>());
          }

          [HttpPut(Name = "UpdateTipoPerfil")]
          public ActionResult UpdateTipoPerfil(TipoPerfilUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:TipoPerfiles"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateTipoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<TipoPerfilUpdateDto>());
          }

        
          [HttpDelete("{id}" , Name = "DeleteTipoPerfil")]
          public ActionResult DeleteTipoPerfil(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:TipoPerfiles"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteTipoPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage)); 
                return convertMessage(response, response.ContentAsJson());
           
       
          }
    }
}