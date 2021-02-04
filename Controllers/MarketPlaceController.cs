using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketPlaceController : ControllerBase
    {
        private IMarketPlace _userService;
        public MarketPlaceController(
         IMarketPlace userService)
        {
            _userService = userService;
        }
        // GET api/values
        [HttpGet("KeepAlive")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    

        [HttpGet("GetTitle")]
        [AllowAnonymous]
        public dynamic Getalltitleinfo()
        {
           var lst =   _userService.Getalltitleinfo();
            GlobalResponses globalResponses = new GlobalResponses();

            if (lst != null)
            {
                globalResponses.statuscode = 100;
                globalResponses.statusmessage = "Success";
                globalResponses.obj = lst;
                return globalResponses;
            }
            else
            {
                globalResponses.statuscode = 101;
                globalResponses.statusmessage = "Not found!";
                return globalResponses;
            }
        }

        [HttpGet("Searchbyname")]
        [AllowAnonymous]
        public dynamic searchbyname(string searchparams)
        {
            var lst = _userService.searchbyname(searchparams);
            GlobalResponses globalResponses = new GlobalResponses();

            if (lst != null)
            {
                globalResponses.statuscode = 100;
                globalResponses.statusmessage = "Success";
                return lst;
            }
            else
            {
                globalResponses.statuscode = 101;
                globalResponses.statusmessage = "Not found!";
                return lst;
            }
        }

        [HttpGet("Gettitledetail")]
        [AllowAnonymous]
        public dynamic Gettitledetail(int titleid)
        {
            var lst = _userService.Gettitledetail(titleid);
            GlobalResponses globalResponses = new GlobalResponses();

            if (lst != null)
            {
                globalResponses.statuscode = 100;
                globalResponses.statusmessage = "Success";
                globalResponses.obj = lst;
                return globalResponses;
            }
            else
            {
                globalResponses.statuscode = 101;
                globalResponses.statusmessage = "Not found!";
                return globalResponses;
            }
        }
        

    }
}
