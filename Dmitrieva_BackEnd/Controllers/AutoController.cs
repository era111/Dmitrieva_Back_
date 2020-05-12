using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZ_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AZ_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        [HttpGet("token")]
        public string GetToken()
        {
            return Auto.GenerateToken();
        }
        [HttpGet("token/secret")]
        public string GetAdminToken()
        {
            return Auto.GenerateToken(true);
        }
    }
}