using Business.Abstracts;
using Business.Concretes;
using Business.Results;
using Entities.Concrete;
using Entities.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IUserService _userService; // Dependency Injection

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = _userService.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return Ok(new { status = 401, isSuccess = false, message = "Invalid User !!!" });
                }

                return Ok(new { status = 200, isSuccess =  true, message = "User Successfully Registered..." });
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured" });
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = _userService.LoginUser(model);

                if(res.Errors.Count > 0)
                {
                    return Ok(new { status = 401, isSuccess = false, message = "Invalid User" });
                }

                HttpContext.Session.SetString("login", JsonConvert.SerializeObject(res.Result));
                return Ok(new { status = 200, isSuccess = true, message = "Successfully Logined...", data = res.Result });
            }

            return BadRequest(new { status = 404, isSuccess = false, message = "Error Occured !!!" });
        }
    }
}
