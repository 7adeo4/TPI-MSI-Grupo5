// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using SuperMamiApi.Commands.EnvioCommands;
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


//     }

//     //dotnet ef dbcontext scaffold "User ID=administrador@dbtpimsi; Password=Contra123*; SslMode=Prefer;Server=dbtpimsi.postgres.database.azure.com; Database=super_mami_entregas;Integrated Security=true;Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models
// }


