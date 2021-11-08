namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class ShippingTypesController : controllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<ShippingController> _logger;

        public ShippingController(ILogger<ShippingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Shipping/GetAllShippingsType")]
        public ActionResult<ResultAPI> GetAllTypeOfShippings()
        {
            var resultado = new ResultAPI();
            var s = db.ShippingType.ToList().Where(c => c.IsActive == true).FirstOrDefault();
            if (s != null)
            {
                resultado.Ok = true;
                resultado.Return = s;
                resultado.AdditionalInfo = "Se cargó la lista correctamente";
                resultado.ErrorCode = 200;
                return resultado;
            }
            else
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar los tipos de envios";
                resultado.ErrorCode = 400;
                return resultado;
            }
        }
    }
}