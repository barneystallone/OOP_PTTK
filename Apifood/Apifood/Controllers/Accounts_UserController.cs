using Apifood.Database;
using Apifood.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Accounts_UserController : ControllerBase
    {

        private readonly DemoDbContext _context;

        public Accounts_UserController(DemoDbContext context)
        {
            _context = context;
        }

        [Authorize(AuthenticationSchemes = "AuthKey")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { state = 1, User.Identity.Name });
        }

        [Route("User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetUser()
        {
            //  var customer = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await _context.Customer.ToListAsync();
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<IEnumerable<Customer>>> Login([FromBody] Login_UserModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.customername == model.UserName);

            if (customer != null && BCrypt.Net.BCrypt.Verify(model.Password, customer.customerpassword))
            {
                // get token
                string secret = "g2sL6RLQh6dVRSSnCRjvEqP971-V2DGpFoUleIfKrIc";
                string iss = "dcaea177e8d14f1fb863059dde75ca3b";
                string audience = "Demo Backend";

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, customer.customername),
                    new Claim(ClaimTypes.Name, customer.customername),
                    new Claim(ClaimTypes.Email, customer.customeremail),
                    new Claim("Role", customer.customername),
                    new Claim("CustomerID", customer.customerid.ToString()),
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
