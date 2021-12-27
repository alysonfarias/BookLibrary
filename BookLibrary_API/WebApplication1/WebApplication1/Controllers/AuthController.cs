using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Data.VO;

namespace WebApplication1.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user) 
        {
            if (user == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            
            return Ok(token);
        
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh ([FromBody] TokenVO tokenVo)
        {
            if (tokenVo is null) return BadRequest("Invalid client request");
            var token = _loginBusiness.ValidateCredentials(tokenVo);
            if(token == null) return BadRequest("Invalid client request token is null");
            return Ok(token);
        }


        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke([FromBody] TokenVO tokenVo)
        {
            var username = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(username);
            if (!result) return BadRequest("Invalid client request");
            return NoContent() ;
        }
    }

}
