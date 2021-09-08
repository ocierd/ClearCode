using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clear.CodeSample.WebUI.Controllers
{
    public class BaseController : ControllerBase
    {

        private const int ServerErrorStatusCode = 500;
        public BaseController()
        {

        }


        protected ObjectResult GetConflictResult(Exception exception)
        {
            string message = exception.Message;
            //return StatusCode(ServerErrorStatusCode,message);
            return Conflict(message);
        }

    }
}
