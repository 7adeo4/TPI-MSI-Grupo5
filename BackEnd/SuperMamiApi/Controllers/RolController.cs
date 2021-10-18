using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands;
using SuperMamiApi.Models;
using SuperMamiApi.Resultados;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class RolController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<RolController> _logger;

        public RolController(ILogger<RolController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Rol/GetRol")]
        public ActionResult<ResultadoAPI> GetRol()
        {
            var resultado = new ResultadoAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Roles.ToList();
                resultado.InfoAdicional = "Se cargó la lista correctamente";
                resultado.CodigoError = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar los roles" + ex.Message;
                resultado.CodigoError = 400;
                return resultado;
            }
        }


    }
}