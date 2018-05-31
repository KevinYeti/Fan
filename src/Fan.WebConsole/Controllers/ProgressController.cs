using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fan.WebConsole.Controllers
{
    [Produces("application/json")]
    [Route("api/Progress")]
    public class ProgressController : Controller
    {
        [HttpGet("{id}")]
        public float Get(string id)
        {


            return 0f;
        }
    }
}