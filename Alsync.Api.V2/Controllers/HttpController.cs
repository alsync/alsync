using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alsync.Api.V2.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class HttpController : ControllerBase
    {
    }
}