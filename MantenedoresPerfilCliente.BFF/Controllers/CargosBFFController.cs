


using MantenedoresPerfilCliente.Application.Cargos.Dtos;
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
    public class CargosBFFController : ControllerBase
    {

        private readonly ILogger<CargosBFFController> _logger;
        private readonly IConfiguration _configuration;

        public CargosBFFController(ILogger<CargosBFFController> logger, IConfiguration configuration)
        {

            this._logger = logger;
            this._configuration = configuration;
        }

        private ActionResult convertMessage(HttpResponseMessage message, object content)
        {
            switch (message.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(content);

                case System.Net.HttpStatusCode.Created:
                    return new CreatedResult(message.RequestMessage.RequestUri, message.ContentAsJson());

                case System.Net.HttpStatusCode.BadRequest:
                    return BadRequest();

                case System.Net.HttpStatusCode.Unauthorized:
                    return Unauthorized();

                case System.Net.HttpStatusCode.NotFound:
                    return NotFound();

                default:
                    return new StatusCodeResult(((int)message.StatusCode));


            }

        }

        [HttpGet(Name = "CargosLoad")]
        public ActionResult CargosLoad()
        {

            string token = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token").Result;
            var response0 = HttpRequestFactory.Get(_configuration["Endpoints:Cargos"], token).Result;
            _logger.LogInformation(string.Format("GetCargos: StatusCode:{0} , RequestMessage:{1} ", response0.StatusCode, response0.RequestMessage));
            var ret = response0.ContentAsType<List<CargoDto>>();

            return convertMessage(response0, ret);

        }



        [HttpPost(Name = "CreateCargo")]
        public ActionResult CreateCargo(CargoInsertDto dto)
        {


            string token = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token").Result;
            var response = HttpRequestFactory.Post(_configuration["Endpoints:Cargos"], dto, token).Result;
            _logger.LogInformation(string.Format("CreateCargo: StatusCode:{0} , RequestMessage:{1} ", response.StatusCode, response.RequestMessage));
            return convertMessage(response, response.ContentAsType<CargoInsertDto>());
        }

        [HttpPut(Name = "UpdateCargo")]
        public ActionResult UpdateCargo(CargoUpdateDto dto)
        {
            string token = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token").Result;
            var response = HttpRequestFactory.Put(_configuration["Endpoints:Cargos"], dto, token).Result;
            _logger.LogInformation(string.Format("UpdateCargo: StatusCode:{0} , RequestMessage:{1} ", response.StatusCode, response.RequestMessage));
            return convertMessage(response, response.ContentAsType<CargoUpdateDto>());
        }


        [HttpDelete("{id}", Name = "DeleteCargo")]
        public ActionResult DeleteCargo(int id)
        {
            string token = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(HttpContext, "access_token").Result;
            var response = HttpRequestFactory.Delete(_configuration["Endpoints:Cargos"] + "/" + id, token).Result;
            _logger.LogInformation(string.Format("DeleteCargo: StatusCode:{0} , RequestMessage:{1} ", response.StatusCode, response.RequestMessage));
            return convertMessage(response, response.ContentAsJson());


        }
    }
}