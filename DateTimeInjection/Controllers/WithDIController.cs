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
    public class WithDIController : ControllerBase
    {
        private readonly IDateTimeService dateTimeService;

        public WithDIController(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        [HttpGet]
        public string Get()
        {
            return dateTimeService.Now().ToString();
        }


    }

    public interface IDateTimeService
    {
        DateTime Now();
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }

}
