using Application.DTOs;
using Application.Services.Contracts;
using Domain.enums;
using Infra.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("user")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        public UserController(IUserService userService,
            ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpGet("get-user-data")]
        [Authorize(Roles = "Basic, Admin")]
        public async Task<IActionResult> GetUserData()
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var id = tokenService.GetIdFromToken(token);

            var user = await userService.GetUser(id);
            return CustomResponse(user);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO dto)
        {
            var response = await userService.Login(dto);

            if(!response.IsValid)
                return Unauthorized(response.Errors.Select(e => e.ErrorMessage));

            var user = await userService.GetUserByEmail(dto.EmailAddress);

            var token = tokenService.GenerateToken(user);

            var result = new LoginResponse{
                AccessToken = token
            };

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO dto)
        {
            dto.ReceiveEmail = false;
            var response = await userService.Create(dto);
            
            if(!response.IsValid)
                return BadRequest(response.Errors.Select(e => e.ErrorMessage));
            
            var user = await userService.GetUserByEmail(dto.EmailAddress);

            var token = tokenService.GenerateToken(user);

            var result = new LoginResponse{
                AccessToken = token
            };
            
            return Ok(result);
        }

        [HttpPost("edit")]
        [Authorize(Roles = "Basic, Admin")]
        public async Task<IActionResult> Update([FromBody] UserDTO dto)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var id = tokenService.GetIdFromToken(token);
            dto.Id = id;
            return CustomResponse(await userService.Update(dto));
        }

        [HttpPost("change-email")]
        [Authorize(Roles = "Basic, Admin")]
        public async Task<IActionResult> ChangeEmail([FromBody] UserDTO dto)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var id = tokenService.GetIdFromToken(token);
            dto.Id = id;
            return CustomResponse(await userService.ChangeEmail(dto));
        }

        [HttpPost("change-password")]
        [Authorize(Roles = "Basic, Admin")]
        public async Task<IActionResult> ChangePassword([FromBody] UserDTO dto)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var id = tokenService.GetIdFromToken(token);
            dto.Id = id;
            return CustomResponse(await userService.ChangePassword(dto));
        }
    }

    public class LoginResponse
    {
        public string AccessToken { get; set; }
    }
}