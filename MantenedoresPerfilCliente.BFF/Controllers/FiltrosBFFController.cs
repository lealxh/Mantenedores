

using MantenedoresPerfilCliente.Application.EstadoFiltros.Dtos;
using MantenedoresPerfilCliente.Application.Filtros.Dtos;
using MantenedoresPerfilCliente.Application.Perfiles.Dtos;
using MantenedoresPerfilCliente.Application.Universos.Dtos;
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
    public class FiltrosBFFController : ControllerBase
    {
      
            private readonly ILogger<FiltrosBFFController> _logger;
            private readonly IConfiguration _configuration;

            public FiltrosBFFController(ILogger<FiltrosBFFController> logger, IConfiguration configuration)
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
          
          [HttpGet("{loadAll}", Name = "FiltrosLoad")]
          public ActionResult FiltrosLoad(bool loadAll)
          {
                 FiltrosLoadDto ret= new FiltrosLoadDto()
                 { 
                    Filtros=new List<FiltroDto>(),
                    Estados=new List<EstadoFiltroDto>(),
                    Universos=new List<UniversoDto>(),
                    Perfiles=new List<PerfilDto>()
                 };
               
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
          
                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:Filtros"],token).Result;
                 _logger.LogInformation(string.Format("GetFiltros: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 ret.Filtros = response0.ContentAsType<List<FiltroDto>>();
                
                if(response0.IsSuccessStatusCode)
                {
                    if(loadAll)
                    { 
                        var response1=  HttpRequestFactory.Get(_configuration["Endpoints:EstadoFiltros"],token).Result;
                        _logger.LogInformation(string.Format("GetEstadosFiltros: StatusCode:{0} , RequestMessage:{1} ",response1.StatusCode,response1.RequestMessage));
                        ret.Estados = response1.ContentAsType<List<EstadoFiltroDto>>();

                        var response2=  HttpRequestFactory.Get(_configuration["Endpoints:Universos"],token).Result;
                        _logger.LogInformation(string.Format("GetUniversos: StatusCode:{0} , RequestMessage:{1} ",response2.StatusCode,response2.RequestMessage));
                        ret.Universos = response2.ContentAsType<List<UniversoDto>>();

                        var response3=  HttpRequestFactory.Get(_configuration["Endpoints:Perfiles"],token).Result;
                        _logger.LogInformation(string.Format("GetPerfiles: StatusCode:{0} , RequestMessage:{1} ",response3.StatusCode,response3.RequestMessage));
                        ret.Perfiles = response3.ContentAsType<List<PerfilDto>>();

                    }
                }

                return convertMessage(response0,ret);
              
            }
           

        // POST: api/Perfils
          [HttpPost(Name = "CreateFiltro")]
          public ActionResult CreateFiltro(FiltroInsertDto dto)
          {


                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:Filtros"],dto,token).Result;
                _logger.LogInformation(string.Format("CreateFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response,response.ContentAsType<FiltroDto>());
          }

          [HttpPut(Name = "UpdateFiltro")]
          public ActionResult UpdateFiltro(FiltroUpdateDto dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:Filtros"],dto,token).Result;
               _logger.LogInformation(string.Format("UpdateFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsType<FiltroUpdateDto>());
          }

        
          [HttpDelete("{id}",Name="DeleteFiltro")]
          public ActionResult DeleteFiltro(int id)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response= HttpRequestFactory.Delete(_configuration["Endpoints:Filtros"]+"/"+id,token).Result;
                _logger.LogInformation(string.Format("DeleteFiltro: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                
                return convertMessage(response, response.ContentAsType<FiltroUpdateDto>());
            
       
          }
    }
}