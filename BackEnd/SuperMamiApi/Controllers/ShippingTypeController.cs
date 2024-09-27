using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Models;
using SuperMamiApi.Results;
using LinqToDB;

namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class ShippingType : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<ShippingType> _logger;

        public ShippingType(ILogger<ShippingType> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ShippingType/GetShippingTypeAverage")]
        public ActionResult<ResultAPI> GetShippingTypeAverage()
        {
            var resultado = new ResultAPI();

            var querry = from s in db.Shippings
                         join sc in db.ShippingCompanies on s.IdShippingCompany equals sc.IdShippingCompany
                         group new { sc.IdShippingType } by sc.IdShippingType into g
                         select new { Tipo_de_envío = g.Key, Cantidad_tipo_envío = g.Count() };

            //var querry = from s in db.Shippings
            //             where s.IdShipping == p_idShipping
            //             select s;

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