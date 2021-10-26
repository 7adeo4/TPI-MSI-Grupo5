// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using SuperMamiApi.Commands.ShippingCommands;
// using SuperMamiApi.Models;
// using SuperMamiApi.Results;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.EntityFrameworkCore;


// namespace SuperMamiApi.Controllers
// {
//     [ApiController]
//     [EnableCors("speMsi")]
//     public class EnvioController : ControllerBase
//     {
//         private readonly super_mami_entregasContext db = new super_mami_entregasContext();
//         private readonly ILogger<EnvioController> _logger;

//         public EnvioController(ILogger<EnvioController> logger)
//         {
//             _logger = logger;
//         }

//          [HttpPost]
//         [Route("Shipping/GetShippingById")]
//         public ActionResult<ResultAPI> Get([FromBody] CommandFindShipping shipping)
//         {
//             var resultado = new ResultAPI();
//             try
//             {

//                 var s = db.Shippings.ToList().Where(c => c.IdShipping == shipping.IdShipping).FirstOrDefault();
//                 if (s != null)
//                 {
//                     resultado.Ok = true;
//                     resultado.Return = s;
//                     resultado.AdditionalInfo = "Se muestra el envío correctamente";
//                     resultado.ErrorCode = 200;
//                     return resultado;
//                 }
//                 else
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Envío no encontrado";
//                     resultado.ErrorCode = 400;
//                     return resultado;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Error al cargar Envíos" + ex.Message;
//                 resultado.ErrorCode = 400;
//                 return resultado;
//             }
//         }

//         [HttpPost]
//         [Route("Shipping/RegisterShipping")]
//         public ActionResult<ResultAPI> RegisterShipping([FromBody] CommandRegisterShipping command)
//         {
//             ResultAPI result = new ResultAPI();
//             Shipping s = new Shipping();

//             s.IdShippingCompany = command.IdShippingCompany;
//             s.IdState = command.IdState;
//             s.DeliveryOrderNumber = command.DeliveryOrderNumber;
//             s.Surname = command.Surname;
//             s.Name = command.Name;
//             s.Surname = command.Surname;
//             s.Phone = command.Phone;
//             s.Address = command.Address;
//             s.Hour = command.Hour;
//             s.Day = command.Day;
//             s.IdZone = command.IdZone;
//             s.IsOwner = command.IsOwner;
//             s.IdUser = command.IdUser;

//             try
//             {
//                  if (s.IdShippingCompany <= 0)
//                 {
//                     result.Ok = false;
//                     result.Error = "Ese tipo de documento no existe";
//                     return result;
//                 }
//                  if (s.IdState <= 0)
//                 {
//                     result.Ok = false;
//                     result.Error = "Ese tipo de documento no existe";
//                     return result;
//                 }
//                   if (s.DeliveryOrderNumber <= 0)
//                 {
//                     result.Ok = false;
//                     result.Error = "Ese rol no existe";
//                     return result;
//                 }
//                 if (s.Name == "")
//                 {
//                     result.Ok = false;
//                     result.Error = "Ingrese el nombre del usuario porfavor";
//                     return result;
//                 }
//                 if (s.Surname == "")
//                 {
//                     result.Ok = false;
//                     result.Error = "Ingrese el apellido del usuario porfavor";
//                     return result;
//                 }
//                 if (s.Phone == 0)
//                 {
//                     result.Ok = false;
//                     result.Error = "Ingrese el email del usuario porfavor";
//                     return result;
//                 }
//                 if (s.Address == "")
//                 {
//                     result.Ok = false;
//                     result.Error = "Ingrese un número válido para el usuario porfavor";
//                     return result;
//                 }
//                 if (s.Hour <= TimeSpan.FromHours(8))
//                 {
//                     result.Ok = false;
//                     result.Error = "Ese rol no existe";
//                     return result;
//                 }
//                 if (s.Password == "")
//                 {
//                     result.Ok = false;
//                     result.Error = "Ingrese una contraseña válida";
//                     return result;
//                 }

//                 db.Users.Add(s);
//                 db.SaveChanges();
//                 result.Ok = true;
//                 var usuarios = db.Users.ToList();

//                 result.Return = usuarios;
//             }

//             catch (Exception ex)
//             {
//                 result.Ok = false;
//                 result.Error = "Algo salió mal al cargar el Usuario. Error: " + ex.ToString();
//             }
//             return result;
//         }

//         [HttpPut]
//         [Route("User/UpdateUser")]
//         public ActionResult<ResultAPI> UpdateUser([FromBody] CommandUpdateUser command)
//         {
//             ResultAPI result = new ResultAPI();
//             User u = new User();
//             if (u.Name == "")
//             {
//                 result.Ok = false;
//                 result.Error = "Ingrese el nombre del usuario porfavor";
//                 return result;
//             }
//             if (u.Surname == "")
//             {
//                 result.Ok = false;
//                 result.Error = "Ingrese el apellido del usuario porfavor";
//                 return result;
//             }
//             if (u.Email == "")
//             {
//                 result.Ok = false;
//                 result.Error = "Ingrese el email del usuario porfavor";
//                 return result;
//             }
//             if (u.Phone == "")
//             {
//                 result.Ok = false;
//                 result.Error = "Ingrese un número válido para el usuario porfavor";
//                 return result;
//             }
//             if (u.Password == "")
//             {
//                 result.Ok = false;
//                 result.Error = "Ingrese una contraseña válida";
//                 return result;
//             }
//             var usu = db.Users.Where(c => c.DocumentNumber == command.DocumentNumber).FirstOrDefault();
//             if (usu != null)
//             {
//                 usu.Name = command.Name;
//                 usu.Surname = command.Surname;
//                 usu.Email = command.Email;
//                 usu.Phone = command.Phone;
//                 usu.Password = command.Password;
//                 db.Users.Update(usu);
//                 db.SaveChanges();
//                 result.Ok = true;
//                 result.Return = db.Users.ToList();
//                 return result;
//             }
//             else
//             {
//                 result.Ok = false;
//                 result.ErrorCode = 200;
//                 result.Error = "Usuario no encontrado, revise el Documento";
//                 return result;
//             }
//         }


//     }

//     //dotnet ef dbcontext scaffold "User ID=administrador@dbtpimsi; Password=Contra123*; SslMode=Prefer;Server=dbtpimsi.postgres.database.azure.com; Database=super_mami_entregas;Integrated Security=true;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models
// }


