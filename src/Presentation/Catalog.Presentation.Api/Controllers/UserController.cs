using Catalog.Core.Application.Features.Users.ConfirmEmail;
using Catalog.Core.Application.Features.Users.CreateUser;
using Catalog.Core.Application.Features.Users.ForgotPassword;
using Catalog.Core.Application.Features.Users.Login;
using Catalog.Core.Application.Features.Users.ResetPassword;
using Catalog.Presentation.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Olivitec.Timesheet.Service.API.Controllers
{
    [Route("api/users")]
    public class UserController(IMediator mediator) : CustomController
    {
        private readonly IMediator _mediator = mediator;

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return Created();
        }

        [AllowAnonymous]
        [HttpPatch("confirm")]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }
    }
}
