using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SıgnIn(CreateLoginDto loginDto)
        {
            string query = "Select * From AppUser Where Username=@username and Password=@password";
            string query2 = "Select UserId From AppUser Where Username=@username and Password=@password";

            var paramaters = new DynamicParameters();
            paramaters.Add("@username", loginDto.Username);
            paramaters.Add("@password", loginDto.Password);
            using (var connection = _context.CreateConnection()) 
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, paramaters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIdDto>(query2, paramaters);


                if (values != null) 
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.UserName = values.Username;
                    model.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
