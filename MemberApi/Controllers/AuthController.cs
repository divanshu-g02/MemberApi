using MemberApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MemberApi.Helper;
using MemberApi.Interface;

namespace MemberApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenHelper _tokenHelper;
        private readonly IMemberService _memberService;

        public AuthController(TokenHelper tokenHelper, IMemberService memberService)
        {
            _tokenHelper = tokenHelper;
            _memberService = memberService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var member = _memberService.ValidateUser(model.Email, model.Password);

            if (member == null )
            {
                return Unauthorized("Invalid Credentatials");
            }
                var token = _tokenHelper.GenerateAccessToken(model.Email);
                return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) });
        }

       

    }
}
