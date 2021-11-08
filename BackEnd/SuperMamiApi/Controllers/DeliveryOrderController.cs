using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands.DeliveryOrderCommands;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using LinqToDB;


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

        [HttpPost]
        [Route("DeliveryOrder/GetMonthlyBillingsForAParticularYear")]
        public ActionResult<ResultAPI> GetMonthlyBillingsForAParticularYear([FromBody] CommandGetMonthlyBillingsForAParticularYear command)
        {
            var resultado = new ResultAPI();

            var querry = from doo in db.DeliveryOrders
                         where doo.DeliveryDate.Year == command.Year
                         group doo by doo.DeliveryDate into g
                         select new { Mes_de_facturación = g.Key.Month, Facturación_máxima = g.Max(z => z.ShippingPrice), Facturación_mínima = g.Min(z => z.ShippingPrice) };

            try
            {
                resultado.Ok = true;
                resultado.Return = querry;
                resultado.AdditionalInfo = "Se cargó la lista correctamente";
                resultado.ErrorCode = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar las sucursales" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }

        [HttpPost]
        [Route("DeliveryOrder/GetTotalShippingsAndPickups")]
        public ActionResult<ResultAPI> GetTotalShippingsAndPickups([FromBody] CommandGetMonthlyBillingsForAParticularYear command)
        {
            var resultado = new ResultAPI();

            var querry = from doo in db.DeliveryOrders
                         join s in db.Shippings on doo.IdDeliveryOrder equals s.IdDeliveryOrder
                         join p in db.Pickups on doo.IdDeliveryOrder equals p.IdDeliveryOrder
                         where p.IsActive == true || s.IsActive == true
                         group new {doo.IdDeliveryOrder,s.IdShipping,p.IdPickup} by doo.DeliveryDate into g
                         select new { Año = g.Key.Year.ToString(), Cantidad_envíos = g.Select(z => z.IdShipping).Distinct().Count(), Cantidad_retiros = g.Select(z => z.IdPickup).Distinct().Count() };

            try
            {
                resultado.Ok = true;
                resultado.Return = querry;
                resultado.AdditionalInfo = "Se cargó la lista correctamente";
                resultado.ErrorCode = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar las sucursales" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }
    }
}


