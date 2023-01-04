using Apifood.Database;
using Apifood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly DemoDbContext _context;

        public AccountsController(DemoDbContext context)
        {
            _context = context;
        }

        [Authorize(AuthenticationSchemes = "AuthKey")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { state = 1, User = User.Identity.Name });
        }

        [Route("admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<adminLogin>>> Getadmin()
        {
            return await _context.admin.ToListAsync();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<IEnumerable<adminLogin>>> Login([FromBody] LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.admin.FirstOrDefaultAsync(x => x.UserName == model.UserName);

            if (admin != null && BCrypt.Net.BCrypt.Verify(model.Password, admin.Password))
            {
                string secret = "g2sL6RLQh6dVRSSnCRjvEqP971-V2DGpFoUleIfKrIc";
                string iss = "dcaea177e8d14f1fb863059dde75ca3b";
                string audience = "Demo Backend";

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier, admin.UserName),
                new Claim(ClaimTypes.Name, admin.UserName),
                new Claim(ClaimTypes.Email, "nguyendong310501@gmail.com"),
                new Claim("AdminID", admin.adminid.ToString()),        
                };

                var jwt = new JwtSecurityToken(
                issuer: iss,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(60 * 60),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);

                return Ok(new
                {
                    access_token = jwtToken,        
                });
            }

            return BadRequest(new { state = "invalid username or password" });
        }



    }
}
