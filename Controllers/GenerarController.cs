using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    public class GenerarController : Controller
    {
        public IActionResult Index()
        {
            return new ViewAsPdf("Index")
            {

            };
        }
    }
}
