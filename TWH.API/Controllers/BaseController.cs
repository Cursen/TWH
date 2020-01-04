using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TWH.Repository;

namespace TWH.API.Controllers
{
    public class BaseController : ApiController
    {
        public UnitOfWork unitOfWork { get; set; }
        public BaseController()
        {
            unitOfWork = new UnitOfWork();
        }
    }
}
