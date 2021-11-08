using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Models;
using SuperMamiApi.Results;

namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class StateController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<StateController> _logger;

        public StateController(ILogger<StateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("State/GetAllStates")]
        public ActionResult<ResultAPI> GetAllStates()
        {
             var result = new ResultAPI();
            try
            {

                    result.Ok = true;
                    result.Return = db.States.ToList();
                    result.AdditionalInfo = "Se muestra la empresa de envío correctamente";
                    result.ErrorCode = 200;
                    return result;
                

            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Error al cargar la empresa de envío" + ex.Message;
                result.ErrorCode = 400;
                return result;
            }
        }
    }
}
