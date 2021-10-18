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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(ILogger<TipoDocumentoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("TipoDocumento/GetTipoDocumento")]
        public ActionResult<ResultadoAPI> GetTipoDocumento()
        {
            var resultado = new ResultadoAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.TipoDocumentos.ToList();
                resultado.InfoAdicional = "Se cargó la lista correctamente";
                resultado.CodigoError = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar tipos de documento" + ex.Message;
                resultado.CodigoError = 400;
                return resultado;
            }
        }


    }
}