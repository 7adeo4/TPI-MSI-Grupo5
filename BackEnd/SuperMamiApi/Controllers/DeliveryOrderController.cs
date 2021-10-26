using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class DeliveryOrderController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<DeliveryOrderController> _logger;

        public DeliveryOrderController(ILogger<DeliveryOrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DeliveryOrder/GetAllDeliveryOrder")]
        public ActionResult<ResultAPI> GetTipoDocumento()
        {
            var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.DeliveryOrders.ToList();
                resultado.AdditionalInfo = "Se cargó la lista correctamente";
                resultado.ErrorCode = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar ordenes de entrega" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }

        [HttpPost]
        [Route("DeliveryOrder/GetDeliveryOrderByID")]
        public ActionResult<ResultAPI> Get([FromBody] CommandFindDeliveryOrder order)
        {
            var resultado = new ResultAPI();
            try
            {

                var dO = db.DeliveryOrders.ToList().Where(c => c.IdDeliveryOrder == order.IdDeliveryOrder).FirstOrDefault();
                if (dO != null)
                {
                    resultado.Ok = true;
                    resultado.Return = dO;
                    resultado.AdditionalInfo = "Se muestra la orden de entrega correctamente";
                    resultado.ErrorCode = 200;
                    return resultado;
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Error = "orden de entrega no encontrada";
                    resultado.ErrorCode = 400;
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar la orden de entrega" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }

    }
}