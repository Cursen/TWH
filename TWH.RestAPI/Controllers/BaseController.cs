using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWH.Repository;

namespace TWH.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public UnitOfWork unitOfWork { get; set; }
        public BaseController()
        {
            unitOfWork = new UnitOfWork();
        }
    }
}