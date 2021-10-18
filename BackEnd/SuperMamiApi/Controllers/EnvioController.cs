// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using SuperMamiApi.Commands;
// using SuperMamiApi.Models;
// using SuperMamiApi.Resultados;
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

//         [HttpPost]
//         [Route("Envio/GetEnvio")]
//         public ActionResult<ResultadoAPI> Get([FromBody] CommandBuscarEnvio envio)
//         {
//             var resultado = new ResultadoAPI();
//             try
//             {

//                 var alu = db.Usuarios.ToList().Where(c => c.IdUsuario == envio.IdUsuario).FirstOrDefault();
//                 if (alu != null)
//                 {
//                     resultado.Ok = true;
//                     resultado.Return = alu;
//                     resultado.InfoAdicional = "Se muestra el usuario correctamente";
//                     resultado.CodigoError = 200;
//                     return resultado;
//                 }
//                 else
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Usuario no encontrado";
//                     resultado.CodigoError = 400;
//                     return resultado;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Error al cargar Usuarios" + ex.Message;
//                 resultado.CodigoError = 400;
//                 return resultado;
//             }
//         }

//         [HttpPost]
//         [Route("Usuario/AltaUsuario")]
//         public ActionResult<ResultadoAPI> AltaUsuario([FromBody] CommandAltaUsuario comando)
//         {
//             ResultadoAPI resultado = new ResultadoAPI();
//             Usuario u = new Usuario();

//             u.IdTipoDocumento = comando.IdTipoDocumento;
//             u.NroDocumento = comando.NroDocumento;
//             u.Nombre = comando.Nombre;
//             u.Apellido = comando.Apellido;
//             u.Email = comando.Email;
//             u.Telefono = comando.Telefono;
//             u.IdRol = comando.IdRol;
//             u.Contrasenia = comando.Contrasenia;

//             try
//             {
//                  if (u.IdTipoDocumento <= 0)
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ese tipo de documento no existe";
//                     return resultado;
//                 }
//                 if (u.NroDocumento == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese el nro de documento del usuario porfavor";
//                     return resultado;
//                 }
//                 if (u.Nombre == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese el nombre del usuario porfavor";
//                     return resultado;
//                 }
//                 if (u.Apellido == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese el apellido del usuario porfavor";
//                     return resultado;
//                 }
//                 if (u.Email == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese el email del usuario porfavor";
//                     return resultado;
//                 }
//                 if (u.Telefono == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese un número válido para el usuario porfavor";
//                     return resultado;
//                 }
//                 if (u.IdRol <= 0)
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ese rol no existe";
//                     return resultado;
//                 }
//                 if (u.Contrasenia == "")
//                 {
//                     resultado.Ok = false;
//                     resultado.Error = "Ingrese una contraseña válida";
//                     return resultado;
//                 }

//                 db.Usuarios.Add(u);
//                 db.SaveChanges();
//                 resultado.Ok = true;
//                 var usuarios = db.Usuarios.ToList();

//                 resultado.Return = usuarios;
//             }

//             catch (Exception ex)
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Algo salió mal al cargar el Usuario. Error: " + ex.ToString();
//             }
//             return resultado;
//         }

//         [HttpPut]
//         [Route("Usuario/UpdateUsuario")]
//         public ActionResult<ResultadoAPI> UpdateUsuario([FromBody] CommandUpdateUsuario comando)
//         {
//             ResultadoAPI resultado = new ResultadoAPI();
//             Usuario u = new Usuario();
//             if (u.Nombre == "")
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Ingrese el nombre del usuario porfavor";
//                 return resultado;
//             }
//             if (u.Apellido == "")
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Ingrese el apellido del usuario porfavor";
//                 return resultado;
//             }
//             if (u.Email == "")
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Ingrese el email del usuario porfavor";
//                 return resultado;
//             }
//             if (u.Telefono == "")
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Ingrese un número válido para el usuario porfavor";
//                 return resultado;
//             }
//             if (u.Contrasenia == "")
//             {
//                 resultado.Ok = false;
//                 resultado.Error = "Ingrese una contraseña válida";
//                 return resultado;
//             }
//             var usu = db.Usuarios.Where(c => c.NroDocumento == comando.NroDocumento).FirstOrDefault();
//             if (usu != null)
//             {
//                 usu.Nombre = comando.Nombre;
//                 usu.Apellido = comando.Apellido;
//                 usu.Email = comando.Email;
//                 usu.Telefono = comando.Telefono;
//                 usu.Contrasenia = comando.Contrasenia;
//                 db.Usuarios.Update(usu);
//                 db.SaveChanges();
//                 resultado.Ok = true;
//                 resultado.Return = db.Usuarios.ToList();
//                 return resultado;
//             }
//             else
//             {
//                 resultado.Ok = false;
//                 resultado.CodigoError = 200;
//                 resultado.Error = "Usuario no encontrado, revise el Documento";
//                 return resultado;
//             }
//         }
//     }

//     //dotnet ef dbcontext scaffold "User ID=prog3; Password=Admin1234;Server=localhost; Database=super_mami_entregas;Integrated Security=true;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models 
// }

