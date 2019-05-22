using MantenedoresPerfilCliente.Application.Areas.Dtos;
using MantenedoresPerfilCliente.Application.Cargos.Dtos;
using MantenedoresPerfilCliente.Application.Exclusiones.Dtos;
using MantenedoresPerfilCliente.Application.MotivoBloqueos.Dtos;
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
    public class ExclusionesBFFController : ControllerBase
    {
       
            private readonly ILogger<ExclusionesBFFController> _logger;
            private readonly IConfiguration _configuration;

            public ExclusionesBFFController(ILogger<ExclusionesBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet("{loadAll}", Name = "ExclusionesLoad")]
          public ActionResult ExclusionesLoad(bool loadAll)
          {
            ExlusionesLoadDto ret = new ExlusionesLoadDto()
            {
                Exclusiones = new List<ExclusionDto>(),
                Areas=new List<AreaDto>(),
                Cargos=new List<CargoDto>(),
                Motivos=new List<MotivoBloqueoDto>()
  
            };

            string token = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token").Result;

            var response0 = HttpRequestFactory.Get(_configuration["Endpoints:Exclusiones"], token).Result;
            _logger.LogInformation(string.Format("GetExclusiones: StatusCode:{0} , RequestMessage:{1} ", response0.StatusCode, response0.RequestMessage));
            ret.Exclusiones = response0.ContentAsType<List<ExclusionDto>>();

            if (response0.IsSuccessStatusCode)
            {
                if (loadAll)
                {
                    var response1 = HttpRequestFactory.Get(_configuration["Endpoints:Areas"], token).Result;
                    _logger.LogInformation(string.Format("GetAreas: StatusCode:{0} , RequestMessage:{1} ", response1.StatusCode, response1.RequestMessage));
                    ret.Areas = response1.ContentAsType<List<AreaDto>>();

                    var response2 = HttpRequestFactory.Get(_configuration["Endpoints:Cargos"], token).Result;
                    _logger.LogInformation(string.Format("GetCargos: StatusCode:{0} , RequestMessage:{1} ", response2.StatusCode, response2.RequestMessage));
                    ret.Cargos = response2.ContentAsType<List<CargoDto>>();

                    var response3 = HttpRequestFactory.Get(_configuration["Endpoints:MotivoBloqueos"], token).Result;
                    _logger.LogInformation(string.Format("GetMotivoBloqueos: StatusCode:{0} , RequestMessage:{1} ", response3.StatusCode, response3.RequestMessage));
                    ret.Motivos = response3.ContentAsType<List<MotivoBloqueoDto>>();

                }
            }

            return convertMessage(response0, ret);

        }


        // POST: api/Perfils
        [HttpPost(Name = "CreateExclusion")]
          public ActionResult CreateExclusion(ExclusionInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:Exclusiones"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateExclusion: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<ExclusionDto>());
          }

          [HttpPut(Name = "UpdateExclusion")]
          public ActionResult UpdateExclusion(ExclusionUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:Exclusiones"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateExclusion: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<ExclusionUpdateDto>());
          }

        
          [HttpDelete("{id}",Name="DeleteExclusion")]
          public ActionResult DeleteExclusion(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:Exclusiones"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteExclusion: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<ExclusionUpdateDto>());
            
       
          }
    }
}
