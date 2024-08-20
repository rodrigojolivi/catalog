using Catalog.Core.Application.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Catalog.Presentation.Api.Controllers
{
    [ApiController]
    [EnableRateLimiting(RATE_LIMIT_FIXED)]
    public class CustomController : ControllerBase
    {
        protected const string RATE_LIMIT_FIXED = "fixed";
        protected const string SUCCESS = "Success";
        protected const string ERROR = "Error";
        protected const string NOT_FOUND = "NotFound";

        protected const string ROLE_ADMIN = "Administrador";
        protected const string ROLE_SELLER = "Vendedor,Administrador";
        protected const string ROLE_CUSTOMER = "Cliente,Vendedor,Administrador";

        protected bool HasNotifications(Response response)
        {
            return response.Notifications.Any();
        }

        protected bool NoData(Response response)
        {
            return response.Data == null;
        }

        protected IActionResult BadRequest(Response response)
        {
            return BadRequest(new
            {
                createdAt = DateTime.Now,
                message = ERROR,
                notifications = response.Notifications
            });
        }

        protected new IActionResult NotFound()
        {
            return NotFound(new
            {
                createdAt = DateTime.Now,
                message = NOT_FOUND
            });
        }

        protected new IActionResult Created()
        {
            return Created("", new
            {
                createdAt = DateTime.Now,
                message = SUCCESS
            });
        }

        protected IActionResult Created(Response response)
        {
            return Created("", new
            {
                createdAt = DateTime.Now,
                message = SUCCESS,
                data = response.Data
            });
        }

        protected IActionResult Ok(Response response)
        {
            return Ok(new
            {
                createdAt = DateTime.Now,
                message = SUCCESS,
                data = response.Data
            });
        }
    }
}
