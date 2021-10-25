using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands.PickupCommands;
using SuperMamiApi.Models;
using SuperMamiApi.Resultados;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class UserController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
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

                var p = db.Pickup.ToList().Where(c => c.IdPickup == pickup.IdPickup).FirstOrDefault();
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

        // [HttpPost]
        // [Route("Pickup/RegisterPickup")]
        // public ActionResult<ResultAPI> RegisterPickup([FromBody] CommandRegisterPickup command)
        // {
        //     ResultAPI result = new ResultAPI();
        //     Pickup p = new Pickup();

        //     p.IdDocumentType = command.IdDocumentType;
        //     p.DocumentNumber = command.DocumentNumber;
        //     p.Name = command.Name;
        //     p.Surname = command.Surname;
        //     p.Email = command.Email;
        //     p.Phone = command.Phone;
        //     p.IdRol = command.IdRol;
        //     p.Password = command.Password;

        //     try
        //     {
        //          if (p.IdDocumentType <= 0)
        //         {
        //             result.Ok = false;
        //             result.Error = "Ese tipo de documento no existe";
        //             return result;
        //         }
        //         if (p.DocumentNumber == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese el nro de documento del usuario porfavor";
        //             return result;
        //         }
        //         if (p.Name == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese el nombre del usuario porfavor";
        //             return result;
        //         }
        //         if (p.Surname == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese el apellido del usuario porfavor";
        //             return result;
        //         }
        //         if (p.Email == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese el email del usuario porfavor";
        //             return result;
        //         }
        //         if (p.Phone == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese un número válido para el usuario porfavor";
        //             return result;
        //         }
        //         if (p.IdRol <= 0)
        //         {
        //             result.Ok = false;
        //             result.Error = "Ese rol no existe";
        //             return result;
        //         }
        //         if (p.Password == "")
        //         {
        //             result.Ok = false;
        //             result.Error = "Ingrese una contraseña válida";
        //             return result;
        //         }

        //         db.Users.Add(p);
        //         db.SaveChanges();
        //         result.Ok = true;
        //         var usuarios = db.Users.ToList();

        //         result.Return = usuarios;
        //     }

        //     catch (Exception ex)
        //     {
        //         result.Ok = false;
        //         result.Error = "Algo salió mal al cargar el Usuario. Error: " + ex.ToString();
        //     }
        //     return result;
        // }

        // [HttpPut]
        // [Route("User/UpdateUser")]
        // public ActionResult<ResultAPI> UpdateUser([FromBody] CommandUpdateUser command)
        // {
        //     ResultAPI result = new ResultAPI();
        //     User u = new User();
        //     if (u.Name == "")
        //     {
        //         result.Ok = false;
        //         result.Error = "Ingrese el nombre del usuario porfavor";
        //         return result;
        //     }
        //     if (u.Surname == "")
        //     {
        //         result.Ok = false;
        //         result.Error = "Ingrese el apellido del usuario porfavor";
        //         return result;
        //     }
        //     if (u.Email == "")
        //     {
        //         result.Ok = false;
        //         result.Error = "Ingrese el email del usuario porfavor";
        //         return result;
        //     }
        //     if (u.Phone == "")
        //     {
        //         result.Ok = false;
        //         result.Error = "Ingrese un número válido para el usuario porfavor";
        //         return result;
        //     }
        //     if (u.Password == "")
        //     {
        //         result.Ok = false;
        //         result.Error = "Ingrese una contraseña válida";
        //         return result;
        //     }
        //     var usu = db.Users.Where(c => c.DocumentNumber == command.DocumentNumber).FirstOrDefault();
        //     if (usu != null)
        //     {
        //         usu.Name = command.Name;
        //         usu.Surname = command.Surname;
        //         usu.Email = command.Email;
        //         usu.Phone = command.Phone;
        //         usu.Password = command.Password;
        //         db.Users.Update(usu);
        //         db.SaveChanges();
        //         result.Ok = true;
        //         result.Return = db.Users.ToList();
        //         return result;
        //     }
        //     else
        //     {
        //         result.Ok = false;
        //         result.ErrorCode = 200;
        //         result.Error = "Usuario no encontrado, revise el Documento";
        //         return result;
        //     }
        // }
    }
}

