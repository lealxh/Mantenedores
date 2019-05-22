using MantenedoresPerfilCliente.BFF.Dtos;
using MantenedoresPerfilCliente.BFF.RestClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace MantenedoresPerfilCliente.BFF.Controllers
{
    [EnableCors("CORSPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosBFFController : ControllerBase
    {

            private readonly ILogger<AreasBFFController> _logger;
            private readonly IConfiguration _configuration;

            public UsuariosBFFController(ILogger<AreasBFFController> logger, IConfiguration configuration)
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

          [HttpGet(Name = "GetPublicKey")]
          public ActionResult GetPublicKey()
          {

                var response0 =  HttpRequestFactory.Get(_configuration["Endpoints:Usuarios"]).Result;
                 _logger.LogInformation(string.Format("GetPublicKey: StatusCode:{0} , RequestMessage:{1} ",response0.StatusCode,response0.RequestMessage));
                 var ret = response0.ContentAsType<UsersGetResponseDTO>();
                return convertMessage(response0,ret);

            }



          [HttpPost(Name = "Login")]
          public ActionResult Login(UsersPostDto dto)
          {


               // string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                 var response=  HttpRequestFactory.Post(_configuration["Endpoints:Usuarios"],dto).Result;
                _logger.LogInformation(string.Format("Login: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                UsersPostResponseDTO respAuth=response.ContentAsType<UsersPostResponseDTO>();
                return convertMessage(response,respAuth);
          }

          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
          [HttpPut(Name = "RefreshToken")]
          public ActionResult RefreshToken(PayloadPost dto)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Put(_configuration["Endpoints:Usuarios"],dto,token).Result;
               _logger.LogInformation(string.Format("RefreshToken: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsJson());
          }

          [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
          [HttpGet,Route("{Login}")]
          public ActionResult GetPerfil(string Login)
          {
                string token=Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext,"access_token").Result;
                var response= HttpRequestFactory.Get(_configuration["Endpoints:Perfiles"]+ "/" + Login ,token).Result;
               _logger.LogInformation(string.Format("GetPerfil: StatusCode:{0} , RequestMessage:{1} ",response.StatusCode,response.RequestMessage));
                return convertMessage(response, response.ContentAsJson());
          }



    }
}