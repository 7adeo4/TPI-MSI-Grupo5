using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands.ShippingCommands;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class EnvioController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<EnvioController> _logger;

        public EnvioController(ILogger<EnvioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Shipping/GetAllShippings")]
        public ActionResult<ResultAPI> GetAllShippings()
        {
            var resultado = new ResultAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Shippings.ToList();
                resultado.AdditionalInfo = "Se cargó la lista correctamente";
                resultado.ErrorCode = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar los envíos" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }


        [HttpPost]
        [Route("Shipping/GetShippingById")]
        public ActionResult<ResultAPI> GetShippingById([FromBody] CommandFindShipping shipping)
        {
            var resultado = new ResultAPI();
            try
            {

                var s = db.Shippings.ToList().Where(c => c.IdShipping == shipping.IdShipping).FirstOrDefault();
                if (s != null)
                {
                    resultado.Ok = true;
                    resultado.Return = s;
                    resultado.AdditionalInfo = "Se muestra el envío correctamente";
                    resultado.ErrorCode = 200;
                    return resultado;
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Error = "Envío no encontrado";
                    resultado.ErrorCode = 400;
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar Envíos" + ex.Message;
                resultado.ErrorCode = 400;
                return resultado;
            }
        }

        [HttpPost]
        [Route("Shipping/RegisterShipping")]
        public ActionResult<ResultAPI> RegisterShipping([FromBody] CommandRegisterShipping command)
        {
            ResultAPI result = new ResultAPI();
            Shipping s = new Shipping();

            s.IdShippingCompany = command.IdShippingCompany;
            s.IdDeliveryOrder = command.IdDeliveryOrder;
            s.IdUser = command.IdUser;
            s.IdState = 1;
            s.IsActive = true;

            try
            {
                if (s.IdShippingCompany <= 0)
                {
                    result.Ok = false;
                    result.Error = "Esa empresa de envíos no existe";
                    return result;
                }
                if (s.IdDeliveryOrder <= 0)
                {
                    result.Ok = false;
                    result.Error = "Ese nro de entrega no existe";
                    return result;
                }
                if (s.IdUser <= 0)
                {
                    result.Ok = false;
                    result.Error = "Ese usuario no existe";
                    return result;
                }

                db.Shippings.Add(s);
                db.SaveChanges();
                result.Ok = true;
                var usuarios = db.Shippings.ToList();

                result.Return = usuarios;
            }

            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Algo salió mal al cargar el Envío. Error: " + ex.ToString();
            }
            return result;
        }

        [HttpPut]
        [Route("Shipping/UpdateShipping")]
        public ActionResult<ResultAPI> UpdateShipping([FromBody] CommandUpdateShipping command)
        {
            ResultAPI result = new ResultAPI();
            Shipping s = new Shipping();

            if (s.IdShippingCompany <= 0)
            {
                result.Ok = false;
                result.Error = "Esa empresa de envíos no existe";
                return result;
            }
            if (s.IdState <= 0)
            {
                result.Ok = false;
                result.Error = "Ese estado de envíos no existe";
                return result;
            }

            var shipp = db.Shippings.Where(c => c.IdDeliveryOrder == command.IdDeliveryOrder).FirstOrDefault();
            if (shipp != null)
            {
                shipp.IdShippingCompany = command.IdShippingCompany;
                shipp.IdState = command.IdState;

                db.Shippings.Update(shipp);
                db.SaveChanges();
                result.Ok = true;
                result.Return = db.Shippings.ToList();
                return result;
            }
            else
            {
                result.Ok = false;
                result.ErrorCode = 200;
                result.Error = "Envío no encontrado, revise el Nro de Orden";
                return result;
            }

        }

        [HttpPut]
        [Route("Shipping/DeleteShipping")]
        public ActionResult<ResultAPI> DeleteShipping([FromBody] CommandDeleteShipping command)
        {
            ResultAPI result = new ResultAPI();
            Shipping s = new Shipping();
            var shipp = db.Shippings.Where(c => c.IdDeliveryOrder == command.IdDeliveryOrder).FirstOrDefault();
            if (shipp != null)
            {
                shipp.IsActive = false;

                db.Shippings.Update(shipp);
                db.SaveChanges();
                result.Ok = true;
                result.Return = db.Shippings.ToList();
                return result;
            }
            else
            {
                result.Ok = false;
                result.ErrorCode = 200;
                result.Error = "Envío no encontrado, revise el Nro de Orden";
                return result;
            }
        }
    }

    //dotnet ef dbcontext scaffold "User ID=administrador@dbtpimsi; Password=Contra123*; SslMode=Prefer;Server=dbtpimsi.postgres.database.azure.com; Database=super_mami_entregas;Integrated Security=true;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models
}


