using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands.PickupCommands;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class PickupController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<PickupController> _logger;

        public PickupController(ILogger<PickupController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Pickup/GetPickup")]
        public ActionResult<ResultAPI> Get([FromBody] CommandFindPickup pickup)
        {
            var result = new ResultAPI();
            try
            {

                var p = db.Pickups.ToList().Where(c => c.IdPickup == pickup.IdPickup).FirstOrDefault();
                if (p != null)
                {
                    result.Ok = true;
                    result.Return = p;
                    result.AdditionalInfo = "Se muestra el retiro correctamente";
                    result.ErrorCode = 200;
                    return result;
                }
                else
                {
                    result.Ok = false;
                    result.Error = "Retiro no encontrado";
                    result.ErrorCode = 400;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Error al cargar retiros" + ex.Message;
                result.ErrorCode = 400;
                return result;
            }
        }

        [HttpPost]
        [Route("Pickup/RegisterPickup")]
        public ActionResult<ResultAPI> RegisterPickup([FromBody] CommandRegisterPickup command)
        {
            ResultAPI result = new ResultAPI();
            Pickup r = new Pickup();

            r.IdDeliveryOrder = command.IdDeliveryOrder;
            //Ver estado por defecto, lo toma como cero
            r.IdState = 1;
            r.IdUser = command.IdUser;
            r.Active = true;


            try
            {
                if (r.IdDeliveryOrder <= 0)
                {
                    result.Ok = false;
                    result.Error = "Esa orden de entrega no existe";
                    return result;
                }

                if (r.IdUser <= 0)
                {
                    result.Ok = false;
                    result.Error = "Ese usuario no existe";
                    return result;
                }


                db.Pickups.Add(r);
                db.SaveChanges();
                result.Ok = true;
                var pickup = db.Pickups.ToList();

                result.Return = pickup;
            }

            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Algo salió mal al cargar el retiro. Error: " + ex.ToString();
            }
            return result;
        }

        [HttpPut]
        [Route("Pickup/UpdatePickup")]
        public ActionResult<ResultAPI> UpdateUser([FromBody] CommandUpdatePickup command)
        {
            ResultAPI result = new ResultAPI();
            Pickup r = new Pickup();


            if (r.IdPickup <= 0)
            {
                result.Ok = false;
                result.Error = "Ese retiro no existe";
                return result;
            }
            if (r.IdDeliveryOrder <= 0)
            {
                result.Ok = false;
                result.Error = "Esa orden de entrega no existe";
                return result;
            }

            if (r.IdState <= 0)
            {
                result.Ok = false;
                result.Error = "Ese usuario no existe";
                return result;
            }

            var pick = db.Pickups.Where(c => c.IdDeliveryOrder == command.IdDeliveryOrder).FirstOrDefault();
            if (pick != null)
            {
                 
                pick.IdPickup = command.IdPickup;
                pick.IdDeliveryOrder = command.IdDeliveryOrder;
                pick.IdState = command.IdState;
                
                db.Pickups.Update(pick);
                db.SaveChanges();
                result.Ok = true;
                result.Return = db.Users.ToList();
                return result;
            }
            else
            {
                result.Ok = false;
                result.ErrorCode = 200;
                result.Error = "Retiro no encontrado, revise el Documento";
                return result;
            }
        }
    }
}

