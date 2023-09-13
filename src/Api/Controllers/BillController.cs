using Application.DTOs;
using Application.Services.Contracts;
using Domain.enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("bill")]
    public class BillController : ApiController
    {
        private readonly IBillService billService;
        private readonly ITokenService tokenService;

        public BillController(IBillService billService, ITokenService tokenService)
        {
            this.billService = billService;
            this.tokenService = tokenService;
        }

        [HttpGet("get-bills")]
        [Authorize(Roles = "Basic, Admin, Premium")]
        public async Task<IActionResult> GetUserBills()
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = tokenService.GetIdFromToken(token);
            return CustomResponse(await billService.GetUserBills(userId));
        }

        [HttpPost("create-bill")]
        [Authorize(Roles = "Basic, Admin, Premium")]
        public async Task<IActionResult> CreateBill([FromBody] BillDTO bill)
        {
            return CustomResponse(await billService.Create(bill));
        }

        [HttpPost("edit-bill")]
        [Authorize(Roles = "Basic, Admin, Premium")]
        public async Task<IActionResult> EditBill([FromBody] BillDTO bill)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = tokenService.GetIdFromToken(token);
            return CustomResponse(await billService.Update(bill, userId));
        }

        [HttpDelete("delete-bill")]
        [Authorize(Roles = "Basic, Admin, Premium")]
        public async Task<IActionResult> EditBill(
            [FromQuery(Name = "id")] Guid id)
        {
            var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = tokenService.GetIdFromToken(token);

            return CustomResponse(await billService.Delete(id, userId));
        }
    }
}