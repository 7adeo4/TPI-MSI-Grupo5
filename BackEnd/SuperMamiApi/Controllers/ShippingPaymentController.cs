using System.ComponentModel.Design;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands.ShippingCompanyCommands;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using SuperMamiApi.Commands.ShippingPaymentCommands;

namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class ShippingPaymentController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<ShippingPaymentController> _logger;

        public ShippingPaymentController(ILogger<ShippingPaymentController> logger)
        {
            _logger = logger;
        }

        

        [HttpPost]
        [Route("ShippingPayment/RegisterShippingPayment")]
        public ActionResult<ResultAPI> RegisterShippingPayment([FromBody] DateTime date)
        {
            ResultAPI result = new ResultAPI();


            

            try
            {

                
                if (date == null)
                {
                    result.Ok = false;
                    result.Error = "Ingrese una fecha, por favor.";
                    return result;
                }
                
                var f = db.ShippingPayments.ToList().Where(c => c.Date.Year == date.Year & c.Date.Month == date.Month  ).FirstOrDefault();

                if (f != null)
                {
                    result.Ok = false;
                    result.Error = "La liquidación para ese mes ya ha sido creada.";
                    return result;
                }

                ShippingPayment s = new ShippingPayment();

                var tp = db.DeliveryOrders.ToList().Where(c => c.DeliveryDate.Year == date.Year & c.DeliveryDate.Month == date.Month ).Select(c => c.ShippingPrice).Sum();

                s.TotalPrice = tp;
                s.Date = date;
                s.IsActive = true;
                s.IdShipping = 2;



                db.ShippingPayments.Add(s);
                db.SaveChanges();
                result.Ok = true;
                result.Return = db.ShippingPayments.ToList();
            }

            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Algo salió mal al cargar la liquidación. Error: " + ex.ToString();
            }
            return result;
        }

         [HttpPost]
        [Route("ShippingPayment/GetShippingPaymentByDate")]
        public ActionResult<ResultAPI> GetByDate([FromBody] DateTime date)
        {
            var result = new ResultAPI();
            try
            {

                var p = db.ShippingPayments.ToList().Where(c => c.Date.Year == date.Year & c.Date.Month == date.Month  ).FirstOrDefault();
                if (p != null)
                {
                    result.Ok = true;
                    result.Return = p;
                    result.AdditionalInfo = "Se muestra la liquidación correctamente";
                    result.ErrorCode = 200;
                    return result;
                }
                else
                {
                    result.Ok = false;
                    result.Error = "Liquidación no encontrada";
                    result.ErrorCode = 400;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Error al cargar la liquidación" + ex.Message;
                result.ErrorCode = 400;
                return result;
            }
        }

         [HttpGet]
        [Route("ShippingPayment/GetAll")]
        public ActionResult<ResultAPI> GetAll()
        {
            var result = new ResultAPI();
            try
            {

                    result.Ok = true;
                    result.Return = db.ShippingPayments.ToList();
                    result.AdditionalInfo = "Se muestran las liquidaciones correctamente";
                    result.ErrorCode = 200;
                    return result;
                

            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Error al cargar las liquidaciones" + ex.Message;
                result.ErrorCode = 400;
                return result;
            }
        }
       

        [HttpPut]
        [Route("ShippingPayment/DeleteShippingPayment")]
        public ActionResult<ResultAPI> DeletePayment([FromBody] CommandDeleteShippingPayment command)
        {
            ResultAPI result = new ResultAPI();
            


            if (command.IdShippingPayment <= 0)
            {
                result.Ok = false;
                result.Error = "Esa liquidación no existe";
                return result;
            }
            

            var ship = db.ShippingPayments.Where(c => c.IdShippingPayment == command.IdShippingPayment).FirstOrDefault();
            if (ship != null)
            {
                 
                
                ship.IdShippingPayment = command.IdShippingPayment;
                
                if(ship.IsActive){
                    ship.IsActive = false;
                }else
                    ship.IsActive = true;
                
                
                
                db.ShippingPayments.Update(ship);
                db.SaveChanges();
                result.Ok = true;
                result.Return = db.ShippingPayments.ToList();
                return result;
            }
            else
            {
                result.Ok = false;
                result.ErrorCode = 200;
                result.Error = "Liquidación no encontrada";
                return result;
            }
        }














    }




}

