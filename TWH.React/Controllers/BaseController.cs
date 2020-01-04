using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TWH.Repository;

namespace TWH.React.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork unitOfWork { get; set; }
        public BaseController()
        {
            unitOfWork = new UnitOfWork();
        }
    }
}
