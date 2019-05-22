

using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
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
    public class MotivoBloqueosBFFController : ControllerBase
    {
      
            private readonly ILogger<MotivoBloqueosBFFController> _logger;
            private readonly IConfiguration _configuration;

            public MotivoBloqueosBFFController(ILogger<MotivoBloqueosBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet(Name = "MotivoBloqueosLoad")]
          public ActionResult MotivoBloqueosLoad()
          {
                
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:MotivoBloqueos"],token).Result;
                 _logger.LogInformation(string.Format("GetMotivoBloqueos: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<List<MotivoBloqueoDto>>();
      
                return convertMessage(response0,ret);
              
            }
           

   
          [HttpPost(Name = "CreateMotivoBloqueo")]
          public ActionResult CreateMotivoBloqueo(MotivoBloqueoInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:MotivoBloqueos"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateMotivoBloqueo: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<MotivoBloqueoInsertDto>());
          }

          [HttpPut(Name = "UpdateMotivoBloqueo")]
          public ActionResult UpdateMotivoBloqueo(MotivoBloqueoUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:MotivoBloqueos"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateMotivoBloqueo: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<MotivoBloqueoUpdateDto>());
          }

        
          [HttpDelete("{id}" , Name = "DeleteMotivoBloqueo")]
          public ActionResult DeleteMotivoBloqueo(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:MotivoBloqueos"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteMotivoBloqueo: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage)); 
                return convertMessage(response, response.ContentAsJson());
           
       
          }
    }
}