using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public String Get()
        {
            return "Service is up and running!";
        }
    }
}