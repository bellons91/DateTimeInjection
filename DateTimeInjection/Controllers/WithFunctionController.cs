using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DateTimeInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithFunctionController : ControllerBase
    {
        private readonly Func<DateTime> now;

        public WithFunctionController(Func<DateTime> now = null)
        {
            if (now != null)
            {
                this.now = now;
            }
            else
            {
                this.now = new Func<DateTime>(() => DateTime.UtcNow);
            }
        }

        [HttpGet]
        public string Get()
        {
            return this.now().ToString();
        }
    }
}
