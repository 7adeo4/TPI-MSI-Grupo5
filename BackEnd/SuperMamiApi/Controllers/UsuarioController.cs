using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperMamiApi.Commands;
using SuperMamiApi.Models;
using SuperMamiApi.Resultados;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;


namespace SuperMamiApi.Controllers
{
    [ApiController]
    [EnableCors("speMsi")]
    public class UsuarioController : ControllerBase
    {
        private readonly super_mami_entregasContext db = new super_mami_entregasContext();
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Usuario/AltaUsuario/")]
        public ActionResult<ResultadoAPI> Get([FromBody] CommandBuscarUsuario usuario)
        {
            var resultado = new ResultadoAPI();
            try
            {

                var alu = db.Usuarios.ToList().Where(c => c.IdUsuario == usuario.IdUsuario).FirstOrDefault();
                if (alu != null)
                {
                    resultado.Ok = true;
                    resultado.Return = alu;
                    resultado.InfoAdicional = "Se muestra el usuario correctamente";
                    resultado.CodigoError = 200;
                    return resultado;
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Error = "Usuario no encontrado";
                    resultado.CodigoError = 400;
                    return resultado;
                }

            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar Usuarios" + ex.Message;
                resultado.CodigoError = 400;
                return resultado;
            }

        }


        [HttpPost]
        [Route("Socio/AltaSocio")]
        public ActionResult<ResultadoAPI> AltaUsuario([FromBody] CommandAltaUsuarios comando)
        {
            ResultadoAPI resultado = new ResultadoAPI();
            Usuario u = new Usuario();

            u.Nombre = comando.Nombre;
            u.Apellido = comando.Apellido;
            u.Email = comando.Email;
            u.Telefono = comando.Telefono;
            u.IdRol = comando.IdRol;
            u.Contrasenia = comando.Contrasenia;

            try
            {
                if (u.Nombre == "")
                {
                    resultado.Ok = false;
                    resultado.Error = "Ingrese el nombre del usuario porfavor";
                    return resultado;
                }
                if (u.Apellido == "")
                {
                    resultado.Ok = false;
                    resultado.Error = "Ingrese el apellido del usuario porfavor";
                    return resultado;
                }
                if (u.Email == "")
                {
                    resultado.Ok = false;
                    resultado.Error = "Ingrese el email del usuario porfavor";
                    return resultado;
                }
                if (u.Telefono == "")
                {
                    resultado.Ok = false;
                    resultado.Error = "Ingrese un número válido para el usuario porfavor";
                    return resultado;
                }
                if (u.IdRol <= 0)
                {
                    resultado.Ok = false;
                    resultado.Error = "Ese rol no existe";
                    return resultado;
                }
                if (u.Contrasenia == "")
                {
                    resultado.Ok = false;
                    resultado.Error = "Ingrese una contraseña válida";
                    return resultado;
                }

                db.Usuarios.Add(u);
                db.SaveChanges();
                resultado.Ok = true;
                var usuarios = db.Usuarios.ToList();

                resultado.Return = usuarios;
            }

            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Algo salió mal al cargar el Usuario. Error: " + ex.ToString();
            }
            return resultado;
        }
    }

    //dotnet ef dbcontext scaffold "User ID=prog3; Password=Admin1234;Server=localhost; Database=super_mami_entregas;Integrated Security=true;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models 
}

