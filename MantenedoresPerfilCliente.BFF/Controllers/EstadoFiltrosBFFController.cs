


using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
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
    public class EstadoFiltrosBFFController : ControllerBase
    {
      
            private readonly ILogger<EstadoFiltrosBFFController> _logger;
            private readonly IConfiguration _configuration;

            public EstadoFiltrosBFFController(ILogger<EstadoFiltrosBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet(Name = "EstadoFiltrosLoad")]
          public ActionResult EstadoFiltrosLoad()
          {
                
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:EstadoFiltros"],token).Result;
                 _logger.LogInformation(string.Format("GetEstadoFiltros: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<List<EstadoFiltroDto>>();
      
                return convertMessage(response0,ret);
              
            }
           

   
          [HttpPost(Name = "CreateEstadoFiltro")]
          public ActionResult CreateEstadoFiltro(EstadoFiltroInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:EstadoFiltros"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateEstadoFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<EstadoFiltroInsertDto>());
          }

          [HttpPut(Name = "UpdateEstadoFiltro")]
          public ActionResult UpdateEstadoFiltro(EstadoFiltroUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:EstadoFiltros"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateEstadoFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<EstadoFiltroUpdateDto>());
          }

        
          [HttpDelete("{id}" , Name = "DeleteEstadoFiltro")]
          public ActionResult DeleteEstadoFiltro(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:EstadoFiltros"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteEstadoFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage)); 
                return convertMessage(response, response.ContentAsJson());
           
       
          }
    }
}