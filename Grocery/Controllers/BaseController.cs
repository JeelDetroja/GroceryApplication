using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Grocery.Controllers
{
    public class BaseController : Controller
    {
        //private Uri baseAddress = new Uri("http://localhost:34165/api");

        #region construtor
        public BaseController()
        {

        }
        #endregion construtor
    }
}
