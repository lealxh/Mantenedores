


using MantenedoresPerfilCliente.Application.Universos.Dtos;
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
    public class UniversosBFFController : ControllerBase
    {
      
            private readonly ILogger<UniversosBFFController> _logger;
            private readonly IConfiguration _configuration;

            public UniversosBFFController(ILogger<UniversosBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet(Name = "UniversosLoad")]
          public ActionResult UniversosLoad()
          {
                
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:Universos"],token).Result;
                 _logger.LogInformation(string.Format("GetUniversos: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<List<UniversoDto>>();
      
                return convertMessage(response0,ret);
              
            }
           

   
          [HttpPost(Name = "CreateUniverso")]
          public ActionResult CreateUniverso(UniversoInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:Universos"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateUniverso: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<UniversoInsertDto>());
          }

          [HttpPut(Name = "UpdateUniverso")]
          public ActionResult UpdateUniverso(UniversoUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:Universos"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateUniverso: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<UniversoUpdateDto>());
          }

        
          [HttpDelete("{id}" , Name = "DeleteUniverso")]
          public ActionResult DeleteUniverso(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:Universos"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteUniverso: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage)); 
                return convertMessage(response, response.ContentAsJson());
           
       
          }
    }
}